using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAwarenessController : MonoBehaviour {
    public bool AwareOfPlayer { get; private set; }
    public Vector2 DirectionToPlayer { get; private set; }
    public Vector2 PlayerLocation { get; private set; }

    [SerializeField]
    private float _playerAwarenessDistance;

    private Transform _player;

    private void Awake() {
        _player = GameObject.FindGameObjectWithTag("Player").transform;
        if (_player == null) {
            Debug.LogError("Player not found. Please ensure the player is tagged 'Player'.");
        }
    }

    void Update() {
        if (_player != null) {
            Vector2 enemyToPlayerVector = _player.position - transform.position;
            DirectionToPlayer = enemyToPlayerVector.normalized;
            PlayerLocation = _player.position;

            // if (enemyToPlayerVector.magnitude <= _playerAwarenessDistance) {
            //     AwareOfPlayer = true;
            // }
            // else {
            //     AwareOfPlayer = false;
            // }

            AwareOfPlayer = true;
        }
    }


}
