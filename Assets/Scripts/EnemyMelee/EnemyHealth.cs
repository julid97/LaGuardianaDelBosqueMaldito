using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour
{
    public int lives;
    private bool isDead = false;

    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void Damager(int damage)
    {
        if (isDead) return; // evita seguir recibiendo daño si ya está muerto

        lives -= damage;
        _animator.SetBool("TakeDamage", true);

        if (lives <= 0)
        {
            Die();
        }
        else
        {
            // resetea el bool después de un breve tiempo
            StartCoroutine(ResetTakeDamage());
        }
    }
    private IEnumerator ResetTakeDamage()
    {
        yield return new WaitForSeconds(1.9f);
        _animator.SetBool("TakeDamage", false);
    }
    private void Die()
    {
        isDead = true;

        _animator.SetBool("IsDead", true);

        Destroy(gameObject, 3.2f); 
    }
}
