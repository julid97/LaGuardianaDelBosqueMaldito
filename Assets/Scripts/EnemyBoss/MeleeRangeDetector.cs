using UnityEngine;

public class MeleeRangeDetector : MonoBehaviour
{
    private BossCombatController bossCombat;

    private void Start()
    {
        bossCombat = GetComponentInParent<BossCombatController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            bossCombat.PlayerInMeleeRange();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            bossCombat.PlayerOutOfRange();
        }
    }
            
}