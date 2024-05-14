using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;

    public ContactFilter2D movementFilter;

    public float moveSpeed = 1f;

    [SerializeField]
    private GameObject _bulletTrail;

    [SerializeField]
    private Transform _gunPoint;

    [SerializeField]
    private float _weaponRange = 10f;

    [SerializeField]
    private Animator _muzzleFlashAnimator;

    public int currentWeaponIndex = 0;

    float

            speedX,
            speedY;

    public bool canMove = true;

    private WeaponSelect _weaponSelect;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        _weaponSelect = GetComponent<WeaponSelect>();
    }

    void Update()
    {
        HandleWalk();
        HandleShooting();
        LookAtMouse();
        currentWeaponIndex = _weaponSelect.currentWeaponIndex;
    }

    private void HandleShooting()
    {
        bool isAuto =
            _weaponSelect.currentWeaponIndex == 2 ||
            _weaponSelect.currentWeaponIndex == 4;

        if (isAuto && Input.GetMouseButton(0))
        {
            HandleRayCast();
        }
        else if (!isAuto && Input.GetMouseButtonDown(0))
        {
            HandleRayCast();
        }
    }

    // Shooting animation
    private void HandleRayCast()
    {
        _muzzleFlashAnimator.SetTrigger("Shoot");

        Vector3 mousePosition =
            Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = (mousePosition - _gunPoint.position).normalized;

        var hit =
            Physics2D.Raycast(_gunPoint.position, direction, _weaponRange);

        var trail =
            Instantiate(_bulletTrail, _gunPoint.position, transform.rotation)
                .GetComponent<BulletTrail>();

        if (hit.collider != null)
        {
            trail.SetTargetPosition(hit.point);
            var hittable = hit.collider.GetComponent<IHittable>();
            hittable?.Hit();
        }
        else
        {
            Vector3 endPosition = _gunPoint.position + direction * _weaponRange;
            trail.SetTargetPosition (endPosition);
        }
    }

    private void LookAtMouse()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.up =
            mousePos - new Vector2(transform.position.x, transform.position.y);
    }

    private void HandleWalk()
    {
        speedX = Input.GetAxis("Horizontal");
        speedY = Input.GetAxis("Vertical");
        rb.velocity = new Vector2(speedX * moveSpeed, speedY * moveSpeed);
    }
}

public interface IHittable
{
    void Hit();
}
