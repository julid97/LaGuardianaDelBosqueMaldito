using UnityEngine;

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

        if (lives <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        isDead = true;

        _animator.SetBool("IsDead", true);

        Destroy(gameObject, 3f); 
    }
}
