using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour {

    public int maxHealth = 100;
    public int currentHealth;

    // Start is called before the first frame update
    void Start() {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update() {

    }

    public void TakeDamage(int amount) {
        Debug.Log("Taking damage: " + amount);
        currentHealth -= amount;
        if (currentHealth <= 0) {
            Destroy(gameObject);
        }
    }
}
