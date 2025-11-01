using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCombatMelee : MonoBehaviour
{
    private Animator _animator;
    public Transform swordHit;
    public float swordRange = 0.7f;
    public LayerMask enemyLayer;
    public int damage = 1;

    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnAttackMelee(InputValue value)
    {
        _animator.SetTrigger("AttackMelee");
        StartCoroutine(AttackRoutine());
    }

    private IEnumerator AttackRoutine()
    {
        // Espera hasta el frame donde impacta la espada
        yield return new WaitForSeconds(0.33f);
        // Detecta todos los colliders de los enemigos en un círculo alrededor de la posición del golpe de espada y los guarda en un array
        Collider2D[] enemies = Physics2D.OverlapCircleAll(swordHit.position, swordRange, enemyLayer);

        // Recorre los enemigos detectados
        foreach (var enemy in enemies)
        {
            // Intenta obtener EnemyHealth
            var enemyHealth = enemy.GetComponent<EnemyHealth>();
            if (enemyHealth != null)
            {
                enemyHealth.Damager(damage);
                continue;
            }

            // Intenta obtener EnemyRangedHealth
            var enemyRangedHealth = enemy.GetComponent<EnemyRangedHealth>();
            if (enemyRangedHealth != null)
            {
                enemyRangedHealth.Damager(damage);
                continue;
            }

            //Intenta obtener BossHealth
            var bossHealth = enemy.GetComponent<BossHealth>();
            if (bossHealth != null)
            {
                bossHealth.Damager(damage);
                continue;
            }
        }
    }

    //Dibuja el rango del ataque en la escena
    private void OnDrawGizmosSelected()
    {
        if (swordHit == null) return;
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(swordHit.position, swordRange);
    }
}

