using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField] protected float _fireDelay = -1f;
    [SerializeField] protected Transform _firePoint = null;
    [SerializeField] protected Vector3 _target = Vector3.negativeInfinity;

    protected bool canShoot = true;

    public abstract void Shoot();
    
    public void StartShooting()
    {
        //Debug.Log("Start Shooting");
        canShoot = true;
        StartCoroutine(ShootingRoutine());
    }

    public void StopShooting()
    {
        canShoot = false;
        StopCoroutine(nameof(ShootingRoutine));
    }

    public IEnumerator ShootingRoutine()
    {
        while (canShoot)
        {
            Shoot();
            yield return new WaitForSeconds(_fireDelay);
        }
    }

    private void Start()
    {
        if (_fireDelay == -1f ||
            _firePoint == null ||
            _target == Vector3.negativeInfinity)
        {
            Debug.LogError($"Не выставлены параметры оружия {name} у {transform.parent.gameObject.name}: " +
                           $"fireDelay: {_fireDelay}, firePoint: {_firePoint}, target: {_target}");
            Destroy(this);
        }
    }
}
