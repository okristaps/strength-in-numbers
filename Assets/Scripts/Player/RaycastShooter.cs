using UnityEngine;

public class RaycastShooter : MonoBehaviour {
	[SerializeField]
	private GameObject _bulletTrail;



	[SerializeField]
	private Transform _gunPoint;

	[SerializeField]
	private Animator _muzzleFlashAnimator;


	public void HandleRayCast() {

		_muzzleFlashAnimator.SetTrigger("Shoot");

		float maxDistance = 10f;

		Debug.Log("Shooting");

		RaycastHit2D hit = Physics2D.Raycast(_gunPoint.position, transform.up, maxDistance);

		var trail = Instantiate(_bulletTrail, _gunPoint.position, transform.rotation);

		var trailScript = trail.GetComponent<BulletTrail>();

		if (hit.collider != null) {
			trailScript.SetTargetPosition(hit.point);
			var hittable = hit.collider.GetComponent<IHittable>();
			hittable?.Hit();
			Debug.Log("Hit??");
			Debug.Log(hit.collider.gameObject.tag);
			if (hit.collider.gameObject.tag == "Enemy") {
				Debug.Log("Hit enemy");
				// Call a function specific to hitting an enemy
				hit.collider.gameObject.GetComponent<EnemyHealth>().TakeDamage(50);
			}
		}
		else {

			Debug.Log("Missed??");
			var endPosition = _gunPoint.position + transform.up * maxDistance;
			trailScript.SetTargetPosition(endPosition);
		}
	}
}
