using UnityEngine;

public class GrenadeThrower : MonoBehaviour {
    [SerializeField] private GameObject grenadePrefab;
    [SerializeField] private Transform _gunPoint;
    private float throwSpeed = 5f;

    void Start() {
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

        Vector2 forwardDirection = Quaternion.Euler(0, 0, 90) * transform.right;
        grenadeRb.velocity = forwardDirection * throwSpeed;

        // Schedule the grenade to be destroyed after 2 seconds
        Destroy(grenade, 2f);
    }
}
