using UnityEngine;

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

        if (lives <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        _animator.SetBool("IsDead", true);

        _isDead = true;

        Destroy(gameObject, 1.5f);
    }
}
