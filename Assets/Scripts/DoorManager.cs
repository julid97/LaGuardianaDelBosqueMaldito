using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;

public class DoorManager : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerInventory playerInventory = collision.gameObject.GetComponent<PlayerInventory>();
            if (playerInventory != null)
            {
                if(playerInventory.keys >= 4)
                {
                    Destroy(gameObject);
                }
            }
        }
    }
}
