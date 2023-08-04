using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Serialization;

public class ShootController : MonoBehaviour
{

    [SerializeField] private Transform _firePoint;
    [SerializeField] private WeaponBehaviour _weaponBehaviour;


  
    public void Start()
    {
        WeaponBehaviour weaponBehaviour = _weaponBehaviour;
        Debug.Log(weaponBehaviour.name);
        WeaponRecord data = DataManager.Instance.DataGun.weapons.Find(x => x.Name == _weaponBehaviour.name);
        Debug.Log(data);
        WeaponBehaviour weapon = weaponBehaviour.GetComponent<WeaponBehaviour>();
        Weapon newWeapon = new Weapon();
        newWeapon.WeaponRecord = data;
        Debug.Log(newWeapon);
        weapon.Init(this, newWeapon);

    }
    
    public void Shoot()
    { 
        Debug.Log("Shoot");
        _weaponBehaviour.FirePoint = _firePoint;
        _weaponBehaviour.Attack();
    }
}

