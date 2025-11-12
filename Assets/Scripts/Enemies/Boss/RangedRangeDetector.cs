using UnityEngine;

public class RangedRangeDetector : MonoBehaviour
{
    private BossCombatController _bossCombat;

    private BossMovement _bossMovement;

    private void Start()
    {
        _bossCombat = GetComponentInParent<BossCombatController>();

        _bossMovement = GetComponentInParent<BossMovement>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            _bossCombat.PlayerInRangedRange();

            _bossMovement.isRange = true; 
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            _bossCombat.PlayerOutOfRange();

            _bossMovement.isRange = false; 
        }
    }
}
