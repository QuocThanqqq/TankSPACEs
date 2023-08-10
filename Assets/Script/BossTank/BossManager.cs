using System;
using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEditor;
using UnityEngine;
using UnityEngine.Serialization;

public class BossManager : MonoBehaviour
{
    [Header("Component")]
    [SerializeField] private Transform _towerRotation;
    [SerializeField] private LayerMask _enemyMask;
    [SerializeField] private BossShooting _bossShooting;
   
    
    [Header("Parameter")]
    [SerializeField] private float _targetRange = 5f;
    [SerializeField] private float _rotateSpeed = 5f;
    [SerializeField] private float _fireRate = 1f;
    
    [Header("HEALTH")] 
    [SerializeField] private float _maxHealth;
    [SerializeField] private float _currentHealth;

    [Header("VFX")] 
    [SerializeField] private ParticleSystem _vfxDie;
    
     private Transform _target;
     private float _timeUntilFire;

     private void Start()
     {
         _currentHealth = _maxHealth;
     }

     private void Update()
    {
        if(_target == null)
        {
           FindEnemy();
           return;
           
        }
        RotateTowerGun();

        if(!CheckTarget())
        {
            _target = null; 
        }
        else 
        {
            if (Time.time > _timeUntilFire)
            {
                _bossShooting.BossShoot();                                                         
                _timeUntilFire = Time.time + 1 / _fireRate;
            }
            
        }
       
    }

    private void FindEnemy()
    {
        RaycastHit2D[] hits = Physics2D.CircleCastAll(transform.position, _targetRange, (Vector2)transform.position, 0.5f, _enemyMask);
        if (hits.Length > 0)
        {
            _target = hits[0].transform;
        }
       
    }

    private bool CheckTarget()
    {
        return Vector2.Distance(_target.position, transform.position) <= _targetRange;
        
    }

    private void RotateTowerGun()
    { 
        Vector3 targetDirection = _target.position - _towerRotation.position;
        float targetAngle = Mathf.Atan2(targetDirection.y, targetDirection.x) * Mathf.Rad2Deg - 90f;
        Quaternion targetRotation = Quaternion.Euler(0f, 0f, targetAngle);
        _towerRotation.rotation = Quaternion.Lerp(_towerRotation.rotation, targetRotation, _rotateSpeed * Time.deltaTime);
    }
    
    
    public void TakeDame(float dameAmount)
    {
        _currentHealth -= dameAmount;
        if (_currentHealth <= 0)
        {
            GetComponent<Collider2D>().enabled = false;
            _vfxDie.Play();
            DelayDeath();
        }    
    }
    private async void DelayDeath()
    {
        await UniTask.Delay(500);
        Destroy(gameObject);
    }
}
