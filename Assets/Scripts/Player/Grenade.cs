using UnityEngine;

public class Grenade : MonoBehaviour {
    void Start() {

    }

    private void Update() {
        Debug.Log("Grenade is updating...");
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        Debug.Log("Grenade collided with: " + collision.gameObject.name);

        if (collision.gameObject.CompareTag("Enemy")) {
            Debug.Log("Grenade collided with an enemy!");
            Destroy(collision.gameObject);
        }


    }
}
