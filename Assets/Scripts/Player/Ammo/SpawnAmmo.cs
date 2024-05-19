using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnAmmo : MonoBehaviour {

    private GameObject PistolAmmo;

    private GameObject RifleAmmo;

    private GameObject ShotgunAmmo;

    [SerializeField]
    [Range(0f, 1f)]
    private float spawnProbability = 0.3f;
    void Start() {

        PistolAmmo = GameObject.FindGameObjectWithTag("PistolAmmo");
        RifleAmmo = GameObject.FindGameObjectWithTag("RifleAmmo");
        ShotgunAmmo = GameObject.FindGameObjectWithTag("ShotgunAmmo");
    }

    void Update() {

    }

    public void SpawnTrigger(Vector3 enemyPosition) {
        Debug.Log("Enemy position at death: " + enemyPosition);

        if (Random.value <= spawnProbability) {
            Debug.Log("Spawning ammo");
            GameObject ammoToSpawn = GetRandomAmmo();
            Instantiate(ammoToSpawn, enemyPosition, Quaternion.identity);
        }
        else {
            Debug.Log("No ammo spawned this time.");
        }
    }

    private GameObject GetRandomAmmo() {
        float randomValue = Random.value;

        if (randomValue < 0.4f) {
            return PistolAmmo;
        }
        else if (randomValue < 0.7f) {
            return RifleAmmo;
        }
        else {
            return ShotgunAmmo;
        }
    }
}
