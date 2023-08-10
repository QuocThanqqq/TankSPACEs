using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;


[System.Serializable]
public class Guns
{
    public Transform rightGun, leftGun, centralGun;
}

public class BossShooting : MonoBehaviour 
{
    [Header("BULLET")]
    [SerializeField] private GameObject _bossBullet;
    [SerializeField] private float _bulletSpeed;
    
    [Header("ENEMY WEAPON")]
    [SerializeField] private Guns guns;
    
    
    public void BossShoot() 
    {
        CreateBullet(_bossBullet, guns.centralGun.position, Vector3.down);
        CreateBullet(_bossBullet, guns.rightGun.position, Quaternion.Euler(0, 0, 45) * Vector3.down);
        CreateBullet(_bossBullet, guns.leftGun.position, Quaternion.Euler(0, 0, -45) * Vector3.down);
        
    }
    private void CreateBullet(GameObject bulletPrefab, Vector3 pos, Vector3 rot)
    {
        GameObject bullet = Instantiate(bulletPrefab, pos, Quaternion.identity);
        Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();
        if (bulletRb != null)
        {
            bulletRb.velocity = rot.normalized * _bulletSpeed;
        }
    }
}
