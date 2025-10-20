using UnityEngine;

public class MeleeRangeDetector : MonoBehaviour
{
    private BossCombatController _bossCombat;

    private void Start()
    {
        _bossCombat = GetComponentInParent<BossCombatController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            _bossCombat.PlayerInMeleeRange();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            _bossCombat.PlayerOutOfRange();
        }
    }
            
}