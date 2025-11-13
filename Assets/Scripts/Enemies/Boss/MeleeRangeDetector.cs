using UnityEngine;

public class MeleeRangeDetector : MonoBehaviour
{
    private BossCombatMelee _combatMelee;
    private GameObject _playerInRange;

    private void Awake()
    {
        _combatMelee = GetComponentInParent<BossCombatMelee>();
    }

    private void Update()
    {
        if (_playerInRange != null)
        {
            PlayerHealth playerHealth = _playerInRange.GetComponent<PlayerHealth>();

            if (playerHealth == null || playerHealth.isDead)
            {
                _combatMelee.StopAttack();
                _playerInRange = null;
                return;
            }

            _combatMelee.TryAttack(_playerInRange);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            _playerInRange = collision.gameObject;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            _playerInRange = null;
            _combatMelee.StopAttack();
        }
    }
}
