using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnAmmo : MonoBehaviour {

    private GameObject PistolAmmo;

    private GameObject RifleAmmo;

    private GameObject ShotgunAmmo;

    private GameObject GrenadeAmmo;

    [SerializeField]
    [Range(0f, 1f)]
    private float spawnProbability = 0.3f;
    void Start() {
        PistolAmmo = GameObject.FindGameObjectWithTag("PistolAmmo");
        RifleAmmo = GameObject.FindGameObjectWithTag("RifleAmmo");
        ShotgunAmmo = GameObject.FindGameObjectWithTag("ShotgunAmmo");
        GrenadeAmmo = GameObject.FindGameObjectWithTag("Grenade");

    }

    void Update() {

    }

    public void SpawnTrigger(Vector3 enemyPosition) {

        if (Random.value <= spawnProbability) {
            GameObject ammoToSpawn = GetRandomAmmo();
            Instantiate(ammoToSpawn, enemyPosition, Quaternion.identity);
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
        else if (randomValue < 0.9f) {
            return ShotgunAmmo;
        }
        else {
            return GrenadeAmmo;
        }
    }
}
