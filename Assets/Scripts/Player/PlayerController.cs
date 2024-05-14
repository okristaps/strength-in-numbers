using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;

    public float moveSpeed = 1f;

    [SerializeField]
    private GameObject _bulletTrail;

    [SerializeField]
    private Transform _gunPoint;

    [SerializeField]
    private float _weaponRange = 10f;

    [SerializeField]
    private Animator _muzzleFlashAnimator;

    float

            speedX,
            speedY;

    public bool canMove = true;

    public ContactFilter2D movementFilter;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        speedX = Input.GetAxis("Horizontal");
        speedY = Input.GetAxis("Vertical");
        rb.velocity = new Vector2(speedX * moveSpeed, speedY * moveSpeed);

        HandleShooting();
        LookAtMouse();
    }

    private void HandleShooting()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _muzzleFlashAnimator.SetTrigger("Shoot");

            Vector3 mousePosition =
                Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3 direction = (mousePosition - _gunPoint.position).normalized;

            var hit =
                Physics2D.Raycast(_gunPoint.position, direction, _weaponRange);

            var trail =
                Instantiate(_bulletTrail,
                _gunPoint.position,
                transform.rotation).GetComponent<BulletTrail>();

            if (hit.collider != null)
            {
                trail.SetTargetPosition(hit.point);
                var hittable = hit.collider.GetComponent<IHittable>();
                hittable?.Hit();
            }
            else
            {
                Vector3 endPosition =
                    _gunPoint.position + direction * _weaponRange;
                trail.SetTargetPosition (endPosition);
            }
        }
    }

    private void LookAtMouse()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.up =
            mousePos - new Vector2(transform.position.x, transform.position.y);
    }
}

public interface IHittable
{
    void Hit();
}
