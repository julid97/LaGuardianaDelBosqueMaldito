using UnityEngine;
using System.Collections;

public class EnemyRangedHealth : MonoBehaviour
{
    public int lives;

    private Animator _animator;

    private bool _isDead = false;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void Damager(int damage)
    {
        if (_isDead) return;

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

    public void Die()
    {
        _animator.SetBool("IsDead", true);

        _isDead = true;

        Destroy(gameObject, 1.5f);
    }

    private IEnumerator ResetTakeDamage()
    {
        yield return new WaitForSeconds(0.35f);
        _animator.SetBool("TakeDamage", false);
    }
}
