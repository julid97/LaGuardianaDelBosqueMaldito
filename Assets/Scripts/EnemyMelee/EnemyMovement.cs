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
        if (isChasing && _player != null)
        {
            // Calcula la direcci�n sin normalizar para poder medir la distancia
            Vector2 direction = _player.position - transform.position;

            if (direction.magnitude > 0.05f)
            {
                Vector2 moveDir = direction.normalized;

                _rb.linearVelocity = moveDir * speed;

                // Pasa direcci�n y movimiento al Animator
                _animator.SetFloat("MovementX", moveDir.x);
                _animator.SetFloat("MovementY", moveDir.y);
                _animator.SetFloat("Movement", _rb.linearVelocity.magnitude);

                // Guarda la �ltima direcci�n de movimiento
                _lastDirection = moveDir;
            }
            else
            {
                // Si est� cerca del jugador, se detiene
                _rb.linearVelocity = Vector2.zero;

                // Mantiene la �ltima direcci�n en la que miraba
                _animator.SetFloat("MovementX", _lastDirection.x);
                _animator.SetFloat("MovementY", _lastDirection.y);
                _animator.SetFloat("Movement", 0f);
            }
        }
        else
        {
            // Si no est� persiguiendo, se detiene
            _rb.linearVelocity = Vector2.zero;

            // Mantiene la �ltima direcci�n
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