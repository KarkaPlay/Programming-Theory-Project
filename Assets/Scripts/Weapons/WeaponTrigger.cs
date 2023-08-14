using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WeaponTrigger : MonoBehaviour
{
    [SerializeField] private Weapon _weapon;

    private int _shipsInRange;

    private int ShipsInRange // ENCAPSULATION
    {
        get => _shipsInRange;
        set => _shipsInRange = value < 0 ? 0 : value;
    }

    private void Start()
    {
        _weapon = transform.parent.GetComponent<Weapon>();
    }

    private void OnTriggerEnter(Collider other)
    {
        //ShipsInRange++;
        //Debug.Log($"Trigger Entered by {other.gameObject.name}, objects: {_shipsInRange}");
        //if (ShipsInRange == 1)
        //{
            _weapon.StartShooting();
        //}
    }

    private void OnTriggerExit(Collider other)
    {
        //ShipsInRange--;
        //Debug.Log($"Trigger Exited, objects: {_shipsInRange}");
        //if (ShipsInRange == 0)
        //{
            _weapon.StopShooting();
        //}
    }
}
