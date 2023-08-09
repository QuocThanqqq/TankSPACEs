using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Cysharp.Threading.Tasks;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.Serialization;

public class WeaponController : MonoBehaviour
{
    public static WeaponController Instance;
   
    Dictionary<string, WeaponBehaviour> MainGun = new Dictionary<string, WeaponBehaviour>();
    
    [Header("GUN")] 
    [SerializeField] private WeaponBehaviour _currenWeapon;
    [SerializeField] private Transform _midFirePoint;
    
    [Header(("WEAPON GUN"))]
    [SerializeField] private WeaponBehaviour[] _weaponGun;
    
    [Header("FX")]
    [SerializeField] private ParticleSystem _fireFX;
    [SerializeField] private ParticleSystem _upPowerFX;
    
    [Header("POWER UP")] 
    public int MaxPower;
    public int CurrentPower;

    private void Awake()
    {
        Instance = this;
    }

    public void Start()
    {
        for (int i = 0; i <_weaponGun.Length; i++)
        {
            WeaponBehaviour weaponGun = _weaponGun[i];
            WeaponRecord data = DataManager.Instance.DataGun.weapons.Find(x => x.Name == _weaponGun[i].name);
            MainGun[data.Name] = weaponGun;
            WeaponBehaviour weapon = weaponGun.GetComponent<WeaponBehaviour>();
            Weapon newWeapon = new Weapon();
            newWeapon.WeaponRecord = data;
            weapon.Init(this, newWeapon);
            weaponGun.gameObject.SetActive((false));
        }
        
        SwitchWeapon("DefaultGun");
    }

    private void Update()
    {
        SwitchGun();
    }

    public void WeaponAttack()
    {
         _fireFX.Play();
         _currenWeapon.MidPoint = _midFirePoint;
         _currenWeapon.Attack();
    }
    private void SwitchWeapon(string name)
    {
        WeaponBehaviour newWeapon = MainGun[name];
        if (_currenWeapon != null)
        {
            _currenWeapon.gameObject.SetActive(false);
        }
        _currenWeapon = newWeapon;
        _currenWeapon.gameObject.SetActive(true);
    }

    private void SwitchGun()
    {
        switch (CurrentPower)
        {
            case 1: 
                SwitchWeapon("DefaultGun");
                break;
            case 2:
                SwitchWeapon("PlusGun");
                break;
        }
    }
    
    
    private async void HandlePowerUP()
    {
        _upPowerFX.Play();
        await UniTask.Delay(2000);
        _upPowerFX.Stop();
    }
}

