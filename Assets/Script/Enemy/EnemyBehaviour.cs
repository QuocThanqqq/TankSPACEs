using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class EnemyBehaviour : MonoBehaviour
{
    
    [SerializeField] private DataEnemys _dataEnemys;
    [SerializeField] private Slider _sliderHealth;
    [SerializeField] private float _currentHealth;
    [SerializeField] private ParticleSystem _particleSystemDie;

    
    private void Update()
    {
        _sliderHealth.value = _currentHealth;
    }

    public void DataEnemy(DataEnemys _dataEnemys)
    {
        this._dataEnemys = _dataEnemys;
        _currentHealth = this._dataEnemys.health;
    }
    public void TakeDame(float dameAmount)
    {
        _currentHealth -= dameAmount;
        if (_currentHealth <= 0)
        {
            GetComponent<Collider2D>().enabled = false;
            _particleSystemDie.Play();
            StartCoroutine(DelayDealth());
        }    
    }

    private IEnumerator DelayDealth() 
    {
       yield return  new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }
}
