using UnityEngine;

public class EnemyRangedTrigger : MonoBehaviour
{
    private EnemyRangedCombat _enemyCombat;

    private EnemyRangedMovement _enemyMovement;

    void Awake()
    {
        _enemyCombat = GetComponentInParent<EnemyRangedCombat>();
        _enemyMovement = GetComponentInParent<EnemyRangedMovement>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            _enemyCombat.isRanged = true;

            _enemyMovement.SetPlayerTransform(collision.transform);
            
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            _enemyCombat.isRanged = false;

            _enemyMovement.SetPlayerTransform(null);
        }
    }
}
