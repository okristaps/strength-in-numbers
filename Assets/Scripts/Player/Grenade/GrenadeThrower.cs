using UnityEngine;
using System.Collections;

public class GrenadeThrower : MonoBehaviour {
    [SerializeField] private GameObject grenadePrefab;
    [SerializeField] private Transform _gunPoint;
    [SerializeField] public GameObject explosion;

    private Ammo _ammo;
    private float throwSpeed = 5f;

    void Start() {
        _ammo = GetComponent<Ammo>();
        if (_gunPoint == null) {
            _gunPoint = GetComponent<Transform>();
        }
    }
    public void ThrowGrenade() {
        Vector3 spawnPosition = _gunPoint.position;
        GameObject grenade = Instantiate(grenadePrefab, spawnPosition, Quaternion.identity);

        Rigidbody2D grenadeRb = grenade.GetComponent<Rigidbody2D>();


        if (grenadeRb == null) {
            Debug.LogError("Grenade prefab is missing a Rigidbody2D component.");
            Destroy(grenade);
            return;
        }

        _ammo.DeductGrenade();

        Vector2 forwardDirection = Quaternion.Euler(0, 0, 90) * transform.right;
        grenadeRb.velocity = forwardDirection * throwSpeed;

        StartCoroutine(DestroyGrenadeAfterDelay(grenade, 2f));

    }
    private IEnumerator DestroyGrenadeAfterDelay(GameObject grenade, float delay) {
        yield return new WaitForSeconds(delay);
        Instantiate(explosion, grenade.transform.position, Quaternion.identity);
        Destroy(grenade);
    }

}
