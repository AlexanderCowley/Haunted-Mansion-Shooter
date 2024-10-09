using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IShootable
{
    [SerializeField] int CurrentHealth;
    [SerializeField] int MaxHealth = 3;
    void Awake() 
    {
        CurrentHealth = MaxHealth;
    }

    public void TakeDamage(int damageTaken)
    {
        CurrentHealth -= damageTaken;
    }
}
