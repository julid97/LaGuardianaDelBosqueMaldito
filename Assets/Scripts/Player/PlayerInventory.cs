using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public int arrows;
    public int keys;
    
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
            AddArrows(15);
            
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.CompareTag("Key"))
        {
            AddKeys(1);

            Destroy(collision.gameObject);
        }
    }

    public void AddArrows(int amount)
    {
        arrows += amount;
    }

    public void AddKeys(int amount)
    {
        keys += amount;
    }
}
