using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovements : MonoBehaviour
{   private Rigidbody2D _rigidbody;
    [SerializeField] private float _speed;
    private void Start()
    {
       _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void OnMove(InputValue inputValue) {
        
        var moveInput = inputValue.Get<Vector2>();

        _rigidbody.linearVelocity = moveInput * _speed;


        
    }
}
