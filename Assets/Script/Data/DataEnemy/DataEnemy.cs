using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[Serializable]
public class DataEnemys
{
    public string name;
    public float health;
}
[CreateAssetMenu(fileName ="DataEnemy", menuName ="DataEnemy")]
public class DataEnemy : ScriptableObject
{
   public List<DataEnemys> Enemys = new List<DataEnemys>();
}
