using UnityEngine;

public class RangedRangeDetector : MonoBehaviour
{

    private BossMovement _bossMovement;
    public bool isRanged;
    private void Awake()
    {

        _bossMovement = GetComponentInParent<BossMovement>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {

            _bossMovement.isRange = true; 
            isRanged = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {

            _bossMovement.isRange = false; 
            isRanged = false;
        }
    }
}
