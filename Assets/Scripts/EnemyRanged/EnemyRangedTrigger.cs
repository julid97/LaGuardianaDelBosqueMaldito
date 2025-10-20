using UnityEngine;

public class EnemyRangedTrigger : MonoBehaviour
{
    private EnemyRangedCombat _enemy;

    void Awake()
    {
        _enemy = GetComponentInParent<EnemyRangedCombat>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            _enemy.isRanged = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            _enemy.isRanged = false;
        }
    }
}
