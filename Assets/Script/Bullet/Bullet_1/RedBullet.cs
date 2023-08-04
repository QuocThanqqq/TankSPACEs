using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedBullet : WeaponBehaviour
{
    public override void InitData()
    {
        /// Data
        base.InitData();
        WeaponType = WeaponType.FireGun;
        TypeDamage = new IRedBullet();
        TypeDamage.Init(this);


        ///Bullet
        BYPool bullet = new BYPool();
        bullet.prefab_ = BulletPrefab;
        bullet.namePool = "RedBullet";
        bullet.total = 10;
        BYPoolManager.poolInstance.AddNewPool(bullet);
    }

    public class IRedBullet : IWeapon
    {
        public RedBullet RedBullet;
        public void Init(WeaponBehaviour weaponBehaviour)
        {
            RedBullet = (RedBullet)weaponBehaviour;
        }
        
        public void Attack(float Damage, Action callBack)
        {
            Transform bullet = BYPoolManager.poolInstance.Spawn("RedBullet");
            bullet.gameObject.GetComponent<ProjectileMover>();
            bullet.position = RedBullet.FirePoint.position;
            bullet.rotation = RedBullet.FirePoint.rotation;
            bullet.GetComponent<ProjectileMover>()._bulletName = "RedBullet";
            bullet.GetComponent<ProjectileMover>().Init(RedBullet.Data);
            callBack?.Invoke();

        }
    }
}
