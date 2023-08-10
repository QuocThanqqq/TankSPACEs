using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


[Serializable]
public class WeaponRecord
{
    public string ID;

    public string Name;

    public float Damage;

    public float FireRate;
}

[CreateAssetMenu(fileName = "DataGun", menuName = "DataGun")]
public class DataGun : ScriptableObject
{
    public List<WeaponRecord> weapons = new List<WeaponRecord>();
}
