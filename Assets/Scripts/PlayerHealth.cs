using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int lives = 5;

    public void ChangeHealth(int Damage)
    {  
        lives -= Damage;
        
        if (lives <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        Debug.Log("El player murió");

        gameObject.SetActive(false);
    }
}
