using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCombat : MonoBehaviour
{
    public Transform ArrowStart;
    
    public GameObject arrowPrefab;

    private PlayerInventory inventory;

    private void Start()
    {
        inventory = GetComponent<PlayerInventory>();
    }
    public void Shoot()
    {   
        if (inventory.UseArrow())
        {
           Instantiate(arrowPrefab, ArrowStart.position, Quaternion.identity);
        }
        else
        {
            Debug.Log("No hay flechas para disparar");
        }
        
    }
    private void OnAttack(InputValue value)
    {
        Shoot();
    }
}

