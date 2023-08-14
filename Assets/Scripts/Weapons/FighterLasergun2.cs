using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FighterLasergun2 : Weapon // INHERITANCE
{
    [SerializeField] private Laser _laserPrefab;
    
    void Awake()
    {
        _target = _firePoint.position + Vector3.forward;
    }
    
    public override void Shoot() // POLYMORPHISM
    {
        var laser = Instantiate(_laserPrefab, _firePoint.position, _firePoint.rotation);
        laser.parentShip = transform.parent.gameObject;
    }

    public override IEnumerator ShootingRoutine() // POLYMORPHISM
    {
        while (canShoot)
        {
            Shoot();
            yield return new WaitForSeconds(0.2f);
            Shoot();
            yield return new WaitForSeconds(0.2f);
            Shoot();
            yield return new WaitForSeconds(_fireDelay);
        }
    }
}
