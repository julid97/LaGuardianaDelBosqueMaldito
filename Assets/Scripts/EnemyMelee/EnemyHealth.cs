using Unity.VisualScripting;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
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
        Debug.Log("El enemigo murió");

        gameObject.SetActive(false);
    }

}
