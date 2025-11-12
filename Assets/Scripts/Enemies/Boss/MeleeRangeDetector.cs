using UnityEngine;

public class MeleeRangeDetector : MonoBehaviour
{
    private void Start()
    {   
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {

        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
  
        }
    }
            
}