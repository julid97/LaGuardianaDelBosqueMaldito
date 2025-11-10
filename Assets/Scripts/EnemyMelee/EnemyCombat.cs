using System.Collections;
using UnityEngine;

public class EnemyCombat : MonoBehaviour
{
    public int damage = 1;

    public float attackCooldown = 1.5f;

    private Animator _animator;

    private float _nextAttackTime;

    public bool isAttacking;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    // Método llamado desde EnemyAttackRange
    public void TryAttack(GameObject player)
    {
        if (Time.time >= _nextAttackTime)
        {
            PlayerHealth playerHealth = player.GetComponent<PlayerHealth>();

            if (playerHealth == null || playerHealth.isDead)
                return;

            StartCoroutine(AttackRoutine(playerHealth));
            _nextAttackTime = Time.time + attackCooldown;
        }
    }

    private IEnumerator AttackRoutine(PlayerHealth playerHealth)
    {
        isAttacking = true;

        _animator.SetBool("IsAttacking", true);

        yield return new WaitForSeconds(0.166f);

        if (playerHealth != null && !playerHealth.isDead)
            playerHealth.LoseHealth(damage);

        yield return new WaitForSeconds(0.5f);

        _animator.SetBool("IsAttacking", false);

        isAttacking = false;
    }

    public void StopAttack()
    {
        _animator.SetBool("IsAttacking", false);

        isAttacking = false;
    }
}

