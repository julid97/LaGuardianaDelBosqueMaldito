using UnityEngine;

public class EnemyAttackRange : MonoBehaviour
{
    private EnemyCombat _enemyCombat;

    private GameObject _playerInRange;

    private void Awake()
    {
        _enemyCombat = GetComponentInParent<EnemyCombat>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            _playerInRange = collision.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            _playerInRange = null;

            _enemyCombat.StopAttack();
        }
    }


    private void Update()
    {
        if (_playerInRange != null)
        {
            _enemyCombat.TryAttack(_playerInRange);
        }
    }

}
