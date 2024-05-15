using UnityEngine;

public class RaycastShooter : MonoBehaviour
{
    [SerializeField]
    private GameObject _bulletTrail;

    [SerializeField]
    private Transform _gunPoint;

    [SerializeField]
    private Animator _muzzleFlashAnimator;

    public void HandleRayCast()
    {
        _muzzleFlashAnimator.SetTrigger("Shoot");

        float maxDistance = 10f;

        RaycastHit2D hit =
            Physics2D.Raycast(_gunPoint.position, transform.up, maxDistance);

        var trail =
            Instantiate(_bulletTrail, _gunPoint.position, transform.rotation);

        var trailScript = trail.GetComponent<BulletTrail>();

        if (hit.collider != null)
        {
            trailScript.SetTargetPosition(hit.point);
            var hittable = hit.collider.GetComponent<IHittable>();
            hittable?.Hit();
        }
        else
        {
            var endPosition = _gunPoint.position + transform.up * maxDistance;
            trailScript.SetTargetPosition (endPosition);
        }
    }
}
