using System;
using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    [SerializeField] private float _dameEnemy = 100f;
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private float _bulletSpeed = 2f;
    
    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
       
    }
    public void FixedUpdate()
    {
        Vector2 moveDirection = -_rb.transform.up;
        _rb.velocity = moveDirection * _bulletSpeed;
        
    }
    
    ///Bullet
    private  void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<TankController>().TakeDameTank(_dameEnemy);
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("Wall"))
        {
            Destroy(gameObject);
        }
    }
}

