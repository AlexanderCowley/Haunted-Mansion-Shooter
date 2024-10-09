using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Create Weapon Data")]
public class WeaponData : ScriptableObject
{
    [field:Header("Damage")]
    [field:SerializeField] public int Damage {get; private set;}
    [field:Header("Ammo")]
    [field:SerializeField] public int CurrentAmmo {get; set;}
    [field:SerializeField] public int MaxAmmo  {get; private set;}
    [field:SerializeField] public float FireRate {get; private set;}

    void OnEnable() 
    {
        CurrentAmmo = MaxAmmo;
    }
}
