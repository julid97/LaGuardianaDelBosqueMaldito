using UnityEngine;

public class EnemyRangeTrigger : MonoBehaviour
{
    private EnemyMovement enemy;

    void Awake()
    {
        enemy = GetComponentInParent<EnemyMovement>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            enemy.SetPlayerTransform(collision.transform);

            enemy.isChasing = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            enemy.StopChasing();

            enemy.isChasing = false;
        }
    }
}