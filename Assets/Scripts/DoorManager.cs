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
            Debug.Log("colisiono con el player");
            if (playerInventory != null)
            {
                if(playerInventory.keys >= 3)
                {
                    Debug.Log(playerInventory.keys);
                    Destroy(gameObject);
                }
            }
        }
    }
}
