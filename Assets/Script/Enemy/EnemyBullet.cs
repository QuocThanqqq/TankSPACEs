using System;
using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    [SerializeField] private float _dameEnemy = 100f;


    private void Start()
    {
        StartCoroutine(DelayDestroy());
    }
    
    private  void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<TankController>().TakeDameTank();
            Destroy(gameObject);
        }
    }
    private IEnumerator DelayDestroy()
    {
        yield return new WaitForSeconds(7);
        Destroy(gameObject);
    }
}

