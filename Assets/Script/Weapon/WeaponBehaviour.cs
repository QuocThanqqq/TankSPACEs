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
    [FormerlySerializedAs("ShootController")] public WeaponController _weaponController;
    public IWeapon TypeDamage;
    public WeaponType WeaponType;
    
    public Transform MidPoint;
    public Transform RightPoint;
    public Transform LeftPoint;
    
    public Transform BulletPrefab;
    public Weapon Data;

    public string mName;
    public float mDame;
    public float mFireRate;
    public void Init(WeaponController weaponController, Weapon dataNew)
    {
        this.Data = dataNew;
        mName = Data.WeaponRecord.Name;
        mDame= Data.WeaponRecord.Damage;
        mFireRate = Data.WeaponRecord.FireRate;
        this._weaponController = weaponController;
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
    LaserGun
}

