using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;


public class PlayerHealth : MonoBehaviour
{
    public int health;

    public int maxHealth = 5;

    private bool healed;

    public PlayerMovements playerMovements;

    private Animator _animator;

    public bool isDead = false;
    private void Start()
    {
        health = maxHealth;
        _animator = GetComponent<Animator>();
    }
    public void LoseHealth(int Damage)
    {   
        if (isDead) return;

        health -= Damage;

        _animator.SetBool("TakeDamage", true);
        
        if (health <= 0)
        {
            StartCoroutine(Die());
        }
        else
        {
            StartCoroutine(ResetTakeDamage());
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

    private IEnumerator ResetTakeDamage()
    {
        yield return new WaitForSeconds(0.35f);
        _animator.SetBool("TakeDamage", false);
    }
    public IEnumerator Die()
    {
        _animator.SetBool("IsDead", true);

        isDead = true;

        yield return new WaitForSeconds(1.2f);

        SceneManager.LoadScene("GameOver");
        
    }
}
