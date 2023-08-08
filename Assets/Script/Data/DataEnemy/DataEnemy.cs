using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;


[Serializable]
public class DataEnemys
{
    public float Health;
    public Sprite Sprite;
    public float Dame;
}
[CreateAssetMenu(fileName ="DataEnemy", menuName ="DataEnemy")]
public class DataEnemy : ScriptableObject
{
   public List<DataEnemys> Enemys = new List<DataEnemys>();
}
