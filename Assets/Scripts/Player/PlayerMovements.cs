using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovements : MonoBehaviour
{   
    private Rigidbody2D _rigidbody;

    private Animator _animator;

    private Vector2 _lastDirection;

    private Vector2 _moveInput;

    [SerializeField] private float _speed;
    private void Start()
    {
       _rigidbody = GetComponent<Rigidbody2D>();
       _animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        _rigidbody.linearVelocity = _moveInput * _speed;

        if(_moveInput != Vector2.zero)
        {
            _lastDirection = _moveInput;

            _animator.SetFloat("MovementX", _moveInput.x);
            _animator.SetFloat("MovementY", _moveInput.y);
        }
        else
        {
            _animator.SetFloat("MovementX", _lastDirection.x);
            _animator.SetFloat("MovementY", _lastDirection.y);
        }

        _animator.SetBool("IsMoving", _moveInput != Vector2.zero);
    }
    private void OnMove(InputValue inputValue) {
        
        _moveInput = inputValue.Get<Vector2>();

    }
}
