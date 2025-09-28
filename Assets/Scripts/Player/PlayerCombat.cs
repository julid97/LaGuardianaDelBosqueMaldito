using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCombat : MonoBehaviour
{
    public Transform ArrowStart;
    
    public GameObject arrowPrefab;
  
    public void Shoot()
    {
        Instantiate(arrowPrefab,ArrowStart.position,Quaternion.identity);
    }
    private void OnAttack(InputValue value)
    {
        Shoot();
    }
}

