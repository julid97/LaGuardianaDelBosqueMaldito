using UnityEngine;

public class EnemyRangedTrigger : MonoBehaviour
{
    private EnemyRangedCombat enemy;

    void Awake()
    {
        enemy = GetComponentInParent<EnemyRangedCombat>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            enemy.isRanged = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            enemy.isRanged = false;
        }
    }
}
