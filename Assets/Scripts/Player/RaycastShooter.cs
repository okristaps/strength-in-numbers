using UnityEngine;

public class RaycastShooter : MonoBehaviour {
	[SerializeField]
	private GameObject _bulletTrail;

	private WeaponSelect _weaponSelect;
	private Ammo _ammo;



	[SerializeField]
	private Transform _gunPoint;

	[SerializeField]
	private Animator _muzzleFlashAnimator;


	void Start() {
		_weaponSelect = GetComponent<WeaponSelect>();
		_ammo = GetComponent<Ammo>();
	}

	public void HandleRayCast() {

		_muzzleFlashAnimator.SetTrigger("Shoot");

		RaycastHit2D hit = Physics2D.Raycast(_gunPoint.position, transform.up, _ammo.weaponRanges[_weaponSelect.currentWeaponIndex]);

		var trail = Instantiate(_bulletTrail, _gunPoint.position, transform.rotation);

		var trailScript = trail.GetComponent<BulletTrail>();

		if (hit.collider != null) {
			trailScript.SetTargetPosition(hit.point);
			var hittable = hit.collider.GetComponent<IHittable>();
			hittable?.Hit();
			if (hit.collider.gameObject.tag == "Enemy") {
				// Call a function specific to hitting an enemy
				hit.collider.gameObject.GetComponent<EnemyHealth>().TakeDamage(
					_ammo.weaponDamages[_weaponSelect.currentWeaponIndex]
				);
			}
		}
		else {
			var endPosition = _gunPoint.position + transform.up * _ammo.weaponRanges[_weaponSelect.currentWeaponIndex];
			trailScript.SetTargetPosition(endPosition);
		}
	}
}
