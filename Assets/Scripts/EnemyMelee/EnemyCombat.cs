using UnityEngine;

public class EnemyCombat : MonoBehaviour
{
    public int damage = 1;

    public float attackCooldown = 1.5f;

    private Animator _animator;

    private float _nextAttackTime;

    public bool isAttacking;
    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    // Método que llamamos desde EnemyAttackRange
    public void TryAttack(GameObject player)
    {
        if (Time.time >= _nextAttackTime)
        {
            _animator.SetBool("IsAttacking", true);

            isAttacking = true;

            PlayerHealth playerHealth = player.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.LoseHealth(damage);
            }

            _nextAttackTime = Time.time + attackCooldown;
        }
    }

    public void StopAttack()
    {
        _animator.SetBool("IsAttacking", false);

        isAttacking = false;
    }
}
