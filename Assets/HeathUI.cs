using UnityEngine;
using TMPro;

public class HeathUI : MonoBehaviour
{
    TextMeshProUGUI _text;
    Rails Manager;
    void Awake() 
    {
        Manager = FindAnyObjectByType<Rails>();
        _text = GetComponent<TextMeshProUGUI>();
        UpdateText();
    }

    void OnEnable() 
    {
        Manager.player.DamageTakenHandler += UpdateText;
        _text.text = $"Health: 5";
    }

    public void UpdateText()
    {
        _text.text = $"Health: {Manager.player.CurrentHealth}";
    }
}
