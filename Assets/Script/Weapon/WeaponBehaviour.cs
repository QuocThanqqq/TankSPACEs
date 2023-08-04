using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

[Serializable]
public class Weapon
{ 
    public WeaponRecord WeaponRecord;
}

[System.Serializable]
public class WeaponBehaviour : MonoBehaviour
{
    public ShootController ShootController;
    public IWeapon TypeDamage;
    public WeaponType WeaponType;

    public Transform FirePoint;
    public Transform BulletPrefab;
    public Weapon Data;

    public string mName;
    public float mDame;
    public void Init(ShootController _ShootController, Weapon dataNew)
    {
        this.Data = dataNew;
        
        mName = Data.WeaponRecord.Name;
        mDame= Data.WeaponRecord.Damage;
        this.ShootController = _ShootController;
        InitData();
    }
    public virtual void InitData()
    {

    }
    public void Attack()
    { 
        TypeDamage.Attack(Data.WeaponRecord.Damage, () =>
        {  
            Debug.Log("RunBack");
        });
    }
}
public enum WeaponType
{
    FireGun,
}

