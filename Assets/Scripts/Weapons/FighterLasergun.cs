using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FighterLasergun : Weapon // INHERITANCE
{
    [SerializeField] private Laser _laserPrefab;
    
    void Awake()
    {
        _target = _firePoint.position + Vector3.forward;
    }
    
    public override void Shoot()
    {
        //Debug.Log("Shoot");
        var laser = Instantiate(_laserPrefab, _firePoint.position, _firePoint.rotation);
        laser.parentShip = transform.parent.gameObject;
    }
}
