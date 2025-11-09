using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCombatMelee : MonoBehaviour
{
    private Animator _animator;
    private PlayerMovements _playerMovements;

    public Transform swordHit;        // Punto de golpe de espada
    public float swordRange = 0.7f;   // rango de golpe de la espadda
    public LayerMask enemyLayer;
    public int damage = 1;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _playerMovements = GetComponent<PlayerMovements>();
    }

    private void OnAttackMelee(InputValue value)
    {
        // Obtiene la dirección del ultimo movimiento
        Vector2 lastDir = _playerMovements.lastDirection;

        // Si nunca se movio usa la direccion frente del personaje
        if (lastDir == Vector2.zero) lastDir = Vector2.right;

        // Coloca swordHit en la direccion del ataque
        swordHit.localPosition = lastDir.normalized * swordRange;

       
        _animator.SetTrigger("AttackMelee");

        StartCoroutine(AttackRoutine());
    }

    private IEnumerator AttackRoutine()
    {
        // Espera hasta el frame donde impacta la espada
        yield return new WaitForSeconds(0.33f);

        // Detecta todos los colliders de los enemigos en un círculo
        Collider2D[] enemies = Physics2D.OverlapCircleAll(swordHit.position, swordRange, enemyLayer);
        // Recorre los enemigos detectados
        foreach (var enemy in enemies)
        {
            var enemyHealth = enemy.GetComponent<EnemyHealth>();
            if (enemyHealth != null)
            {
                enemyHealth.Damager(damage);
                continue;
            }

            var enemyRangedHealth = enemy.GetComponent<EnemyRangedHealth>();
            if (enemyRangedHealth != null)
            {
                enemyRangedHealth.Damager(damage);
                continue;
            }

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
