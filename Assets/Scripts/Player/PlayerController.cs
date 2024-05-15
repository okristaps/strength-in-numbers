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

    private WeaponSelect _weaponSelect;

    public int currentWeaponIndex = 0;

    float

            speedX,
            speedY;

    public bool canMove = true;

    private bool isShooting = false;

    private float shotDelay = 0.05f;

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

    private IEnumerator AutoShoot()
    {
        isShooting = true;
        while (isShooting)
        {
            HandleRayCast();
            yield return new WaitForSeconds(shotDelay);
        }
    }

    private void HandleShooting()
    {
        bool isAuto =
            _weaponSelect.currentWeaponIndex == 2 ||
            _weaponSelect.currentWeaponIndex == 4;
        if (isAuto && Input.GetMouseButton(0))
        {
            if (!isShooting)
            {
                StartCoroutine(AutoShoot());
            }
        }
        else if (!isAuto && Input.GetMouseButtonDown(0))
        {
            HandleRayCast();
        }
        if (!Input.GetMouseButton(0))
        {
            isShooting = false;
        }
    }

    // Shooting animation
    private void HandleRayCast()
    {
        _muzzleFlashAnimator.SetTrigger("Shoot");

        float maxDistance = 10f;

        RaycastHit2D hit =
            Physics2D.Raycast(_gunPoint.position, transform.up, maxDistance);

        var trail =
            Instantiate(_bulletTrail, _gunPoint.position, transform.rotation);

        var trailScript = trail.GetComponent<BulletTrail>();

        if (hit.collider != null)
        {
            trailScript.SetTargetPosition(hit.point);
            var hittable = hit.collider.GetComponent<IHittable>();
            hittable?.Hit();
        }
        else
        {
            var endPosition = _gunPoint.position + transform.up * maxDistance;
            trailScript.SetTargetPosition (endPosition);
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
