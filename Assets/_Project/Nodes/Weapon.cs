using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] WeaponData Data;
    Transform _firePoint;

    public delegate void OnFireEvent();
    public event OnFireEvent FireEventHandler;

    void Awake() 
    {
        _firePoint = transform.GetChild(0).GetComponent<Transform>();
        Data.CurrentAmmo = Data.MaxAmmo;
    }

    public void Fire()
    {
        //Ammo decremented
        if(Data.CurrentAmmo > 0) Data.CurrentAmmo--;
        FireEventHandler?.Invoke();
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(ray, out RaycastHit hit))
        {
            if(hit.transform.TryGetComponent<IShootable>(out IShootable shootable))
            {
                shootable.TakeDamage(Data.Damage);
            }
        }
    }
}
