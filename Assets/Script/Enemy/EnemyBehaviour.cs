using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyBehaviour : MonoBehaviour
{
    public static EnemyBehaviour instance;

    [SerializeField]private DataEnemys dataEnemys;
    [SerializeField]private Slider sliderHealth;
    [SerializeField]private Animator anim;
   

    [SerializeField] private float currentHealth;

    public bool isDie = false;




    void Update()
    {
        sliderHealth.value = currentHealth;
    }

    public void DataEnemy(DataEnemys _dataEnemys)
    {
        dataEnemys = _dataEnemys;
        currentHealth = dataEnemys.health;
    }

    public void TakeDame(float dameAmount)
    {
        currentHealth -= dameAmount;
        if (currentHealth <= 0)
        {
    
            isDie = true;
            anim.Play("Death");
            GetComponent<Collider2D>().enabled = false;
            StartCoroutine(DelayDealth());
        }    
    }

    private IEnumerator DelayDealth() 
    {
       yield return  new WaitForSeconds(1f);
        Destroy(gameObject);
    }
}
