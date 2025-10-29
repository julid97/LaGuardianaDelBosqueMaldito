using System;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerHealth : MonoBehaviour
{
    public int health;

    public int maxHealth = 5;

    private bool healed;

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
        healed = false;
        if (health < maxHealth)
        {
            health += lives;

            if (health > maxHealth)
            {
                health = maxHealth;
            }

            healed = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Heart"))
        {
            AddHealth(1);
            if (healed)
            {
                Destroy(collision.gameObject);
            }
 
        }
    }

    public void Die()//este metodo le podria agregar una corutina cuando tenga la animaciond de muerte, activo la animacion y espero unos segundos para ir al menu de pausa
    {
        gameObject.SetActive(false);
        SceneManager.LoadScene("GameOver");
    }
}
