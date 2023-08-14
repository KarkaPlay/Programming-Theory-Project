using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class Starship : MonoBehaviour
{
    // Космический корабль летит с помощью Rigidbody, плавно поворачивается в сторону цели
    
    private Rigidbody _rigidbody;
    [SerializeField] protected float _speed = 30f;
    [SerializeField] protected float _rotaionSpeed = 30f;
    [SerializeField] protected List<Weapon> _weapons;

    public Transform target;
    public float minDistance;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void SetDestination(Transform target)
    {
        Vector3 direction = target.position - transform.position;
        Quaternion toRotation = Quaternion.LookRotation(direction.normalized);
        _rigidbody.MoveRotation(Quaternion.RotateTowards(transform.rotation, toRotation, _rotaionSpeed * Time.fixedDeltaTime));
    }
    
    private void Start()
    {
        if (target !)
        {
            SetDestination(target);
        }
        else
        {
            Debug.LogError($"У корабля {name} не выбрана цель: {target}");
            //Destroy(this);
            ChooseRandomTarget();
            Debug.Log($"У корабля {name} теперь цель: {target}");
        }

        _speed *= Random.Range(0.9f, 1.1f);
        _rotaionSpeed *= Random.Range(0.9f, 1.1f);
    }

    private void FixedUpdate()
    {
        // Если расстояние до target менее minDistance, то выбираем новую цель (случаный корабль)
        /*if (Vector3.Distance(transform.position, target.position) < minDistance)
        {
            target = GameObject.Find("Starship" + Random.Range(1, 4)).transform;
        }*/
        SetDestination(target);
        _rigidbody.AddForce(transform.forward * _speed, ForceMode.Force);
    }

    private void ChooseRandomTarget()
    {
        target = ShipsObserver.Instance.starships[Random.Range(0, ShipsObserver.Instance.starships.Capacity)].transform;
        if (target == gameObject.transform)
        {
            ChooseRandomTarget();
        }
    }
}
