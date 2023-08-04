using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;


public class ProjectileMover : MonoBehaviour
{
   
    [SerializeField]private Rigidbody2D _rb;
    [SerializeField]private float _bulletSpeed = 2f;
    [SerializeField]private Weapon _weaponDame;
    public float _bulletDames;
    public string _bulletName;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
       
    }

    public void Init(Weapon dataBullet)
    {
        this._weaponDame = dataBullet;
        _bulletDames = _weaponDame.WeaponRecord.Damage;

    }

    public void FixedUpdate()
    {
            Vector2 moveDirection = _rb.transform.up;
            _rb.velocity = moveDirection * _bulletSpeed;
        
    }
    private void OnSpawned()
    {
        StopCoroutine(DespawnedDelay());
        StartCoroutine(DespawnedDelay());
    }
    // private void OnCollisionEnter2D(Collision2D collision)
    // {
    //     if (collision.gameObject.layer == 6)
    //     {
    //         //collision.gameObject.GetComponent<EnemyBehaviour>().TakeDame(mDames);
    //         BYPoolManager.poolInstance.DeSpawn(_bulletName, transform);
    //         BYPoolManager.poolInstance.Spawn("hitEnemy").position = transform.position;
    //     }
    //     // if(collision.gameObject.layer == 20)
    //     // {
    //     //     BYPoolManager.poolInstance.DeSpawn(_bulletName, transform);
    //     //     BYPoolManager.poolInstance.Spawn("hitWall").position = transform.position;
    //     // }
    // }
    IEnumerator DespawnedDelay()
    {
        yield return new WaitForSeconds(1f);
        BYPoolManager.poolInstance.DeSpawn(_bulletName, transform);
    }
}