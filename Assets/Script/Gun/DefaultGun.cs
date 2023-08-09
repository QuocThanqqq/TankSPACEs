using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultGun : WeaponBehaviour
{
    public override void InitData()
    {
        /// Data
        base.InitData();
        WeaponType = WeaponType.FireGun;
        TypeDamage = new IDefaultGun();
        TypeDamage.Init(this);


        ///Bullet
        BYPool bullet = new BYPool();
        bullet.prefab_ = BulletPrefab;
        bullet.namePool = "RedBullet";
        bullet.total = 10;
        BYPoolManager.poolInstance.AddNewPool(bullet);
    }

    public class IDefaultGun : IWeapon
    {
        public DefaultGun _defaultGun;
        public void Init(WeaponBehaviour weaponBehaviour)
        {
            _defaultGun = (DefaultGun)weaponBehaviour;
        }
        
        public void Attack(float Damage, Action callBack)
        {
            Transform bullet = BYPoolManager.poolInstance.Spawn("RedBullet");
            bullet.gameObject.GetComponent<ProjectileMover>();
            bullet.position = _defaultGun.MidPoint.position;
            bullet.GetComponent<ProjectileMover>()._bulletName = "RedBullet";
            bullet.GetComponent<ProjectileMover>().Init(_defaultGun.Data);
            callBack?.Invoke();

        }
    }
}
