using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlusGun : WeaponBehaviour
{
    public override void InitData()
    {
        /// Data
        base.InitData();
        WeaponType = WeaponType.LaserGun;
        TypeDamage = new IPlusGun();
        TypeDamage.Init(this);


        ///Bullet
        BYPool bullet = new BYPool();
        bullet.prefab_ = BulletPrefab;
        bullet.namePool = "LaserBullet";
        bullet.total = 10;
        BYPoolManager.poolInstance.AddNewPool(bullet);
    } 
    public class IPlusGun : IWeapon
    {
        public PlusGun PlusGun;
        public void Init(WeaponBehaviour weaponBehaviour)
        {
            PlusGun = (PlusGun)weaponBehaviour;
        }

        public void Attack(float Damage, Action callBack)
        {
         
            Transform bullet = BYPoolManager.poolInstance.Spawn("LaserBullet");
            bullet.gameObject.GetComponent<ProjectileMover>();
            bullet.position = PlusGun.MidPoint.position;
            bullet.GetComponent<ProjectileMover>()._bulletName = "LaserBullet";
            bullet.GetComponent<ProjectileMover>().Init(PlusGun.Data);
            callBack?.Invoke();
        }
        
    }
}
