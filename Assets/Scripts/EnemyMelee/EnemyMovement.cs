using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 2f;

    public bool isChasing;


    private Rigidbody2D _rb;

    private Transform _player;

    private Animator _animator;

    private Vector2 _lastDirection;

    private EnemyCombat _combat;

    [SerializeField] private float _stopMovement = 1.026f;
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();

        _animator = GetComponent<Animator>();

        _combat = GetComponent<EnemyCombat>();
    }

    void FixedUpdate()
    {
        // se mueve si esta persiguiendo al jugador
        if (isChasing && _player != null)
        {
            float distance = Vector2.Distance(transform.position, _player.position);

            Vector2 direction = (_player.position - transform.position).normalized;

            if (_combat != null && _combat.isAttacking)
            {
                _rb.linearVelocity = Vector2.zero;
            }
            else if (distance >= _stopMovement)
            {
                // Se mueve hacia el jugador
                _rb.linearVelocity = direction * speed;

                _animator.SetFloat("MovementX", direction.x);
                _animator.SetFloat("MovementY", direction.y);
                _animator.SetFloat("Movement", _rb.linearVelocity.magnitude);

                _lastDirection = direction;
            }
            else
            {
                // Está lo suficientemente cerca se detiene
                _rb.linearVelocity = Vector2.zero;

                _animator.SetFloat("MovementX", _lastDirection.x);
                _animator.SetFloat("MovementY", _lastDirection.y);
                _animator.SetFloat("Movement", 0f);
            }
        }
        else
        {
            // Si no está persiguiendo
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
