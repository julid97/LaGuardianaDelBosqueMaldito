using UnityEngine;

public class BossHealth : MonoBehaviour
{
    public int lives;

    public void Damager(int damage)
    {
        lives -= damage;

        if (lives <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        gameObject.SetActive(false);
    }
}
