using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour
{
    public int lives;
    private bool _isDead = false;

    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void Damager(int damage)
    {
        if (_isDead) return; // evita seguir recibiendo daño si ya está muerto

        lives -= damage;
        _animator.SetBool("TakeDamage", true);

        if (lives <= 0)
        {
            Die();
        }
        else
        {
            StartCoroutine(ResetTakeDamage());
        }
    }
    private IEnumerator ResetTakeDamage()
    {
        yield return new WaitForSeconds(0.35f);
        _animator.SetBool("TakeDamage", false);
    }
    private void Die()
    {
        _isDead = true;

        _animator.SetBool("IsDead", true);

        Destroy(gameObject, 0.45f); 
    }
}
