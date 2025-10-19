using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 2f;

    public bool isChasing;

    private Rigidbody2D _rb;

    private Transform _player;

    private Animator _animator;

    private Vector2 _lastDirection;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();

        _animator = GetComponent<Animator>();
    }

    void Update()
    {
        // se mueve si esta persiguiendo al jugador
        if (isChasing && _player != null)
        {   
            Vector2 direction = _player.position - transform.position;

            if (direction.magnitude > 0.05f)
            {
                Vector2 moveDir = direction.normalized;

                _rb.linearVelocity = moveDir * speed;

                _animator.SetFloat("MovementX", moveDir.x);
                _animator.SetFloat("MovementY", moveDir.y);
                _animator.SetFloat("Movement", _rb.linearVelocity.magnitude);

                _lastDirection = moveDir;
            }
            else
            {
                // Cerca del jugador se detiene
                _rb.linearVelocity = Vector2.zero;
                _animator.SetFloat("MovementX", _lastDirection.x);
                _animator.SetFloat("MovementY", _lastDirection.y);
                _animator.SetFloat("Movement", 0f);
            }
        }
        else
        {
            // No esta persiguiendo  se detiene
            _rb.linearVelocity = Vector2.zero;
            _animator.SetFloat("MovementX", _lastDirection.x);
            _animator.SetFloat("MovementY", _lastDirection.y);
            _animator.SetFloat("Movement", 0f);
        }
    }

    public void SetPlayerTransform(Transform player)
    {
        _player = player;
    }

    public void StopChasing()
    {
        _player = null;
        isChasing = false;
        _rb.linearVelocity = Vector2.zero;
    }
}