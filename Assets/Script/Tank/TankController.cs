using System;
using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.Serialization;

public class TankController : MonoBehaviour
{ 
    [Header("TANK MOVEMENT")]
    [SerializeField] private float _speed ;
    
    [Header("FIRE")]
    [SerializeField] private ShootController _shootController;
    [SerializeField] private float fireRate = 2f;
    [SerializeField] private float _timeUntilFire;

    [Header("HEALTH")] 
    [SerializeField] private float _health = 10;

    [SerializeField] private bool _isDie;
    
    [Header("FX")] [SerializeField] private ParticleSystem _particleDie;
    
    
    private float _xMovement;
    private float _yMovement;
    private Vector2 _movement;
    private Rigidbody2D _rb;

    private void Awake()
    {
        _isDie = false;
        _rb = GetComponent<Rigidbody2D>();
    }

    

    private void Update()
    {
        Movement();
        Shooter();
    }

    private void Shooter()
    {
        _timeUntilFire += Time.deltaTime;
        if (_timeUntilFire >= 1f / fireRate && _isDie == false )
        { 
            _shootController.Shoot();
            _timeUntilFire = 0;
        }
    }
    private void Movement()
    {
        _xMovement = Input.GetAxisRaw("Horizontal");
        _yMovement = Input.GetAxisRaw("Vertical");
        _movement = new Vector2(_xMovement, _yMovement);
        _rb.MovePosition(_rb.position + _movement * _speed * Time.fixedDeltaTime);
    }

    public  async void TakeDameTank(float dame)
    {
        _health -= dame;
            if (_health <= 0)
            {
                _isDie = true;
                _particleDie.Play();
                await UniTask.Delay(500);
                Destroy(gameObject);
            }
    }
}
