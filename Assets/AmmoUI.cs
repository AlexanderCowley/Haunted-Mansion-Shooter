using UnityEngine;
using TMPro;

public class AmmoUI : MonoBehaviour
{
    TextMeshProUGUI _text;
    [SerializeField] WeaponData WeaponAmmo;

    Rails Manager;

    void Awake() 
    {
        Manager = FindAnyObjectByType<Rails>();
        _text = GetComponent<TextMeshProUGUI>();
    }

    private void OnEnable()
    {
        Manager.player.CurrentWeapon.OnFireEventHandler += UpdateText;
        UpdateText();
    }

    public void UpdateText()
    {
        _text.text = $"Ammo: {WeaponAmmo.CurrentAmmo}";
    }
}
