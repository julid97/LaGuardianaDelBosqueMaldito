using UnityEngine;

public class BossCombatController : MonoBehaviour
{
    public EnemyCombat meleeAttack;

    public BossCombatRanged rangedAttack;

    private void Start()
    {
        meleeAttack.enabled = false;

        rangedAttack.enabled = false;
    }
    public void PlayerInMeleeRange()
    {
        meleeAttack.enabled = true;

        rangedAttack.enabled = false;
    }
    public void PlayerInRangedRange()
    {
        meleeAttack.enabled = false;

        rangedAttack.enabled = true;
    }
    public void PlayerOutOfRange()
    {
        meleeAttack.enabled = false;

        rangedAttack.enabled = false;
    }
}