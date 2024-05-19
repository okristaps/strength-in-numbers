using UnityEngine;
using System.Collections;

public class GrenadeThrower : MonoBehaviour {
    [SerializeField] private GameObject grenadePrefab;
    [SerializeField] private Transform _gunPoint;
    private float throwSpeed = 5f;


    void Start() {
        _gunPoint = GetComponent<Transform>();
    }

    public void ThrowGrenade() {
        Vector3 spawnPosition = _gunPoint.position;
        GameObject grenade = Instantiate(grenadePrefab, spawnPosition, Quaternion.identity);

        // since player is facing up, we need to rotate the forward direction by 90 degrees
        Vector3 forwardDirection = Quaternion.Euler(0, 0, 90) * transform.right;
        StartCoroutine(MoveGrenadeForward(grenade, forwardDirection));
    }

    private IEnumerator MoveGrenadeForward(GameObject grenade, Vector3 direction) {
        float elapsedTime = 0f;
        while (elapsedTime < 1f) {


            grenade.transform.position += direction * throwSpeed * Time.deltaTime;
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        Destroy(grenade);
    }

    public void OnCollisionEnter(Collision collision) {
        Debug.Log("Collision entered");
    }


}
