using UnityEngine;

public class EnemyCombat : MonoBehaviour
{
    public int damage = 1;
    public float attackCooldown = 1.5f;

    private Animator _animator;
    private float _nextAttackTime;

    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (Time.time >= _nextAttackTime)
            {
                // Activar animación de ataque
                _animator.SetBool("IsAttacking", true);

                // Buscar el componente de salud
                PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
                if (playerHealth != null)
                {
                    playerHealth.ChangeHealth(damage);
                }
                // Reiniciar cooldown
                _nextAttackTime = Time.time + attackCooldown;
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {

            _animator.SetBool("IsAttacking", false);
        }
    }
}
