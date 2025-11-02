using UnityEngine;

public class EnemyAttackRange : MonoBehaviour
{
    private EnemyCombat _enemyCombat;
    private GameObject _playerInRange;

    void Awake()
    {
        _enemyCombat = GetComponentInParent<EnemyCombat>();
    }
    private void Update()
    {
        if (_playerInRange != null)
        {
            // Obtenemos el componente PlayerHealth del jugador
            PlayerHealth playerHealth = _playerInRange.GetComponent<PlayerHealth>();

            // Si el jugador murio el enemigo deja de atacar
            if (playerHealth == null || playerHealth.isDead)
            {
                _enemyCombat.StopAttack();
                _playerInRange = null;
                return;
            }

            // Solo si el jugador sigue vivo, ataca
            _enemyCombat.TryAttack(_playerInRange);
        }
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
}
