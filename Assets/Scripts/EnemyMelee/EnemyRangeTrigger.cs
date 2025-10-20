using UnityEngine;

public class EnemyRangeTrigger : MonoBehaviour
{
    private EnemyMovement _enemy;

    void Awake()
    {
        _enemy = GetComponentInParent<EnemyMovement>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            _enemy.SetPlayerTransform(collision.transform);

            _enemy.isChasing = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            _enemy.isChasing = false;
            _enemy.StopChasing();
        }
    }
}