using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField] private float _speed = 10f;
    
    private const float LifeTime = 10f;
    private Rigidbody _rb;
    public GameObject parentShip;

    private void Start()
    {
        StartCoroutine(Destroy());
        //_rb = GetComponent<Rigidbody>();
        //_rb.AddForce(transform.forward * _speed, ForceMode.Impulse);
    }

    private void FixedUpdate()
    {
        transform.Translate(Vector3.forward * _speed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject != parentShip)
        {
            Destroy(gameObject);
        }
    }
    
    private IEnumerator Destroy()
    {
        yield return new WaitForSeconds(LifeTime);
        BulletHit();
    }
    
    private void BulletHit()
    {
        //Instantiate(hitEffectPrefab, transform.position, quaternion.identity);
        Destroy(gameObject);
    }
}
