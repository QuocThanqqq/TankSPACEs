using System;
using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class EnemyBehaviour : MonoBehaviour
{
    public static EnemyBehaviour Instance;
    [Header("DATA")]
    public DataEnemys _dataEnemys;
    
    [Header("HEALTH")]
    [SerializeField] private float _currentHealth;
    [SerializeField] private Slider _sliderHealth;
    
    
    [Header("VFX")]
    [SerializeField] private ParticleSystem _particleSystemDie;
    
    [Header("SPRITE")]
    [SerializeField] private SpriteRenderer _sprite;

    [Header("PROJECTILE")]
    [SerializeField] private GameObject _projectile;
    [SerializeField] private Transform _firePos;
    


  

    private  void Start()
    {
        Invoke("ActivateShooting", Random.Range(5f,6f));
       
    }

    private void Update()
    {
        _sliderHealth.value = _currentHealth;
    }

    public void DataEnemy(DataEnemys _dataEnemys)
    {
        this._dataEnemys = _dataEnemys;
        _currentHealth = this._dataEnemys.Health;
        _sprite.sprite = _dataEnemys.Sprite;
    }
    public void TakeDame(float dameAmount)
    {
        _currentHealth -= dameAmount;
        if (_currentHealth <= 0)
        {
            GetComponent<Collider2D>().enabled = false;
            _particleSystemDie.Play();
            DelayDealth();
        }    
    }

    private void ActivateShooting()
    {
        StartCoroutine(ShootWithRandomDelay());
    }
    
    private IEnumerator ShootWithRandomDelay()
    {
        while (true)
        {
            Instantiate(_projectile, _firePos.position, Quaternion.identity);
            float delay = Random.Range(1f, 3f);
            yield return new WaitForSeconds(delay);
        }
    }
    private async void DelayDealth()
    {
        await UniTask.Delay(500);
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<TankController>().TakeDameTank(_dataEnemys.Dame);
            _particleSystemDie.Play();
             DelayDealth();
        }
    }
}
