using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {
    [SerializeField]
    private float _speed;

    private Rigidbody2D _rigidbody;
    private PlayerAwarenessController _playerAwarenessController;

    private void Awake() {
        _rigidbody = GetComponent<Rigidbody2D>();
        _playerAwarenessController = FindObjectOfType<PlayerAwarenessController>();
    }

    private void FixedUpdate() {
        if (_playerAwarenessController != null && _playerAwarenessController.AwareOfPlayer) {
            Vector2 targetDirection = (_playerAwarenessController.PlayerLocation - (Vector2)transform.position).normalized;
            _rigidbody.velocity = targetDirection * _speed;
        }
        else {
            _rigidbody.velocity = Vector2.zero;
        }
    }
}
