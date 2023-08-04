using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public interface IWeapon
{
    void Init(WeaponBehaviour weaponBehaviour);
    void Attack(float Damage, Action callBack);
 
}
