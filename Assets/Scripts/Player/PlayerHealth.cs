using System;
using UnityEngine;


public class PlayerHealth : MonoBehaviour
{
    public int health;

    public int maxHealth = 5;


    public PlayerMovements playerMovements;

    private void Start()
    {
        health = maxHealth;
    }
    public void LoseHealth(int Damage)
    {  
        health -= Damage;
        
        if (health <= 0)
        {
            Die();
        }
    }

    public void AddHealth(int lives)
    {
        health += lives;

        if (health > maxHealth)
        {
            health = maxHealth;
        }
    }

    public void Die()
    {
        Debug.Log("El player murió");

        gameObject.SetActive(false);
    }
}
