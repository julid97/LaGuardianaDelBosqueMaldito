using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;

public class PlayerCombatRanged : MonoBehaviour
{
    public Transform ArrowStart;
    public GameObject arrowPrefab;

    private PlayerInventory inventory;
    private Camera _targetCamera;
    private Vector2 _pointPosition;
    private Animator _animator;

    private void Start()
    {
        inventory = GetComponent<PlayerInventory>();
        _targetCamera = Camera.main;
        _animator = GetComponent<Animator>();
    }

    private void OnPoint(InputValue value)
    {
        Vector2 screenPos = value.Get<Vector2>();
        _pointPosition = _targetCamera.ScreenToWorldPoint(screenPos);
    }

    private void OnAttackRanged(InputValue value)
    {
        if (inventory.UseArrow())
        {
            _animator.SetTrigger("AttackRanged");
            StartCoroutine(ShootRoutine());
        }
    }

    private IEnumerator ShootRoutine()
    {
        // Espera 0.64 segundos: el momento en que el personaje suelta la flecha
        yield return new WaitForSeconds(0.64f);

        // Instancia y dispara la flecha
        Vector2 direction = (_pointPosition - (Vector2)ArrowStart.position).normalized;

        GameObject arrow = Instantiate(arrowPrefab, ArrowStart.position, Quaternion.identity);
        ArrowController arrowController = arrow.GetComponent<ArrowController>();
        arrowController.direction = direction;
    }
}

