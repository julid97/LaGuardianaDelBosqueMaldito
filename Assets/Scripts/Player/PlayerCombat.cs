using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCombat : MonoBehaviour
{
    public Transform ArrowStart;

    public GameObject arrowPrefab;

    private PlayerInventory inventory;

    private Camera targetCamera;

    private Vector2 _pointPosition;

    private void Start()
    {
        inventory = GetComponent<PlayerInventory>();

        targetCamera = Camera.main;

    }
    public void Shoot()
    {   
        if (inventory.UseArrow())
        {
            Vector2 direction = (_pointPosition - (Vector2)ArrowStart.position).normalized;

            GameObject arrow = Instantiate(arrowPrefab, ArrowStart.position, Quaternion.identity);

            ArrowController arrowController = arrow.GetComponent<ArrowController>();

            arrowController.direction = direction;
        }
        else
        {
            Debug.Log("No hay flechas para disparar");
        }
        
    }

    private void OnPoint(InputValue value)
    {
        Vector2 screenPos = value.Get<Vector2>();

        _pointPosition = targetCamera.ScreenToWorldPoint(screenPos);
    }

    private void OnAttack(InputValue value)
    {
        Shoot();
    }
}

