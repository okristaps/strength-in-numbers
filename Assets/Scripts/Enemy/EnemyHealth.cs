using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour {

    public int maxHealth = 100;
    public int currentHealth;

    [SerializeField]
    private SpawnAmmo _spawnAmmo;


    void Start() {
        currentHealth = maxHealth;
        _spawnAmmo = GetComponent<SpawnAmmo>();
    }

    public void TakeDamage(int amount) {
        currentHealth -= amount;
        if (currentHealth <= 0) {
            Vector3 enemyPosition = transform.position;
            Destroy(gameObject);
            _spawnAmmo.SpawnTrigger(enemyPosition);
        }
    }


}
