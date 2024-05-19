using UnityEngine;

public class Grenade : MonoBehaviour {
    [SerializeField] public GameObject explosion;
    void Start() {

    }

    private void OnCollisionEnter2D(Collision2D collision) {
        Debug.Log("Grenade collided with: " + collision.gameObject.name);
        if (collision.gameObject.CompareTag("Enemy")) {
            Destroy(collision.gameObject);
        }

    }
}
