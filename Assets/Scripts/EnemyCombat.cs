using UnityEngine;

public class EnemyCombat : MonoBehaviour
{  
   public int damage;
    private void OnCollisionEnter2D(Collision2D collision)
    {   
        if (collision.gameObject.CompareTag("Player"))
        {
           PlayerHealth playerhealth = collision.gameObject.GetComponent<PlayerHealth>();

            if (playerhealth != null)
            {
                playerhealth.ChangeHealth(damage);

            }
        }

    }
}
