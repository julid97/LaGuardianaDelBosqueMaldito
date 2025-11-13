using UnityEngine;
using System.Collections;

public class BossCombatMelee : MonoBehaviour
{
    public int damage = 1;
    public float attackCooldown = 1.5f;
    public bool isAttackingMelee;

    private Animator _animator;
    private bool _canAttack = true;
    private float _nextAttackTime;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void TryAttack(GameObject player)
    {
        if (Time.time >= _nextAttackTime && _canAttack)
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
        _canAttack = false;
        isAttackingMelee = true;
        _animator.SetBool("IsAttackingMelee", true);

        yield return new WaitForSeconds(0.166f);

        if (playerHealth != null && !playerHealth.isDead)
            playerHealth.LoseHealth(damage);

        yield return new WaitForSeconds(0.5f);

        _animator.SetBool("IsAttackingMelee", false);
        isAttackingMelee = false;
        _canAttack = true;
    }

    public void StopAttack()
    {
        _animator.SetBool("IsAttackingMelee", false);
        isAttackingMelee = false;
        _canAttack = true;
    }
}

