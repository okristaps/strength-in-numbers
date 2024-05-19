using System.Runtime.CompilerServices;
using UnityEngine;

public class Explostion : MonoBehaviour {



    public float radius = 5;

    void Start() {


    }

    private void Update() {
        Collider2D[] enemyHit = Physics2D.OverlapCircleAll(transform.position, 1f);
        foreach (Collider2D col in enemyHit) {
            Debug.Log("smth smth");
            if (col.CompareTag("Enemy")) {
                Debug.Log("Grenade collided with an enemy!");
                col.gameObject.GetComponent<EnemyHealth>().TakeDamage(100);


            }
        }

    }

    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.black;
        Gizmos.DrawSphere(transform.position, 1f);

    }

    public void EndExplosion() {
        Destroy(gameObject);
    }

}