using System;
using UnityEngine;


public class PlayerHealth : MonoBehaviour
{
    public int health;

    public int maxHealth = 5;

    public SpriteRenderer playerSprite;

    public PlayerMovements playerMovements;

    private void Start()
    {
        health = maxHealth;
    }
    public void ChangeHealth(int Damage)
    {  
        health -= Damage;
        
        if (health <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        Debug.Log("El player murió");

        gameObject.SetActive(false);
    }
}
