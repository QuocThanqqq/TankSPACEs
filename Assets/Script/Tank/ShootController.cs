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
    [SerializeField] private ParticleSystem _fireGun;


  
    public void Start()
    {
        WeaponBehaviour weaponBehaviour = _weaponBehaviour;
        WeaponRecord data = DataManager.Instance.DataGun.weapons.Find(x => x.Name == _weaponBehaviour.name);
        WeaponBehaviour weapon = weaponBehaviour.GetComponent<WeaponBehaviour>();
        Weapon newWeapon = new Weapon();
        newWeapon.WeaponRecord = data;
        weapon.Init(this, newWeapon);

    }
    
    public void Shoot()
    {
        _fireGun.Play();
        _weaponBehaviour.FirePoint = _firePoint;
        _weaponBehaviour.Attack();
    }
}

