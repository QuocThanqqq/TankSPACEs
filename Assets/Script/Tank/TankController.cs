using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class TankController : MonoBehaviour
{ 
    [Header("TANK MOVEMENT")]
    [SerializeField] private float _speed ;
    
    [Header("FIRE")]
    [SerializeField] private ShootController _shootController;
    [SerializeField] private float fireRate = 1f;
    [SerializeField] private float _timeUntilFire;


    
    
    private float _xMovement;
    private float _yMovement;
    private Vector2 _movement;
    private bool _mouse = false;
    private Rigidbody2D _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }
    
    private void Update()
    {
        Movement();
        _timeUntilFire += Time.deltaTime;
        if (_timeUntilFire >= 1f / fireRate )
        {
            _shootController.Shoot();
            _timeUntilFire = 0;
        }
    }

    private void FixedUpdate()
    {
        _rb.MovePosition(_rb.position + _movement * _speed * Time.fixedDeltaTime);
    }

    private void Movement()
    {
        _xMovement = Input.GetAxisRaw("Horizontal");
        _yMovement = Input.GetAxisRaw("Vertical");
        _movement = new Vector2(_xMovement, _yMovement);
    }

}
