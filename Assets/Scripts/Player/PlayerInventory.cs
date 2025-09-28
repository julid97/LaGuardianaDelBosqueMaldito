using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    [SerializeField] private int arrows;
    
    public bool UseArrow()
    {
        if (arrows > 0)
        {
            arrows--;

            return true;

        }
        else { 
            
            return false;

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Arrow"))
        {
            AddArrows(3);
            
            Destroy(collision.gameObject);
        }
    }

    public void AddArrows(int amount)
    {
        arrows += amount;
    }
}
