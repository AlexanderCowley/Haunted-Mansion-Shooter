using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.PackageManager;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] WeaponData Data;
    Transform _firePoint;

    public delegate void OnFireEvent();
    public event OnFireEvent FireEventHandler;

    WaitForSeconds _fireRateDelay;
    WaitForSeconds _reloadDelay;
    bool _canFire = true;
    bool _hasFired = false;
    AudioSource _audioSource;

    LayerMask _layerMask;

    Ray _ray;
    void Awake() 
    {
        _fireRateDelay = new WaitForSeconds(Data.FireRate);
        _reloadDelay = new WaitForSeconds(Data.ReloadSpeed);
        _audioSource = GetComponent<AudioSource>();
        _firePoint = transform.GetChild(0).GetComponent<Transform>();
        Data.CurrentAmmo = Data.MaxAmmo;
        _layerMask = LayerMask.GetMask("Shootable");
    }

    public void Fire()
    {
        if(!_canFire) return;
        //Ammo decremented
        if(Data.CurrentAmmo > 0) 
        {
            Data.CurrentAmmo--;
        }
        else
        {
            _canFire = false;
            StartCoroutine(ReloadDelay());
            return;
        }
        //FireEventHandler?.Invoke();
        _audioSource.Play();
        _ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if(Physics.SphereCast(
            _ray.origin, 5f, _ray.direction, 
            out RaycastHit hit, Mathf.Infinity, _layerMask))
        {
            if(hit.transform.TryGetComponent<IShootable>(out IShootable shootable))
            {
                shootable.TakeDamage(Data.Damage);
            }
        }
        _canFire = false;
        StartCoroutine(Delay(_fireRateDelay));
    }

    IEnumerator ReloadDelay()
    {
        yield return _reloadDelay;
        Data.CurrentAmmo = Data.MaxAmmo;
        _canFire = true;
    }

    IEnumerator Delay(WaitForSeconds delay)
    {
        yield return delay;
        _canFire = true;
    }
}
