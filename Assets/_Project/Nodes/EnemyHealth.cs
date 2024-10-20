using UnityEngine;

public class EnemyHealth : MonoBehaviour, IShootable
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
        if(CurrentHealth <= 0) Death();
    }

    void Death()
    {
        //Replace with object pooling later
        gameObject.SetActive(false);
    }
}
