using System;
using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class PowerUpManager : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(DelayDestroy());
    }

    private  void OnCollisionEnter2D(Collision2D collision)
    {
        
         if (collision.gameObject.CompareTag("Player")) 
         {
                if (WeaponController.Instance.CurrentPower < WeaponController.Instance.MaxPower)
                {
                    WeaponController.Instance.CurrentPower++; 
                }
                Destroy(gameObject);
         }
        
        
    }

    private IEnumerator DelayDestroy()
    {
        yield return new WaitForSeconds(10);
        Destroy(gameObject);
    }
}
