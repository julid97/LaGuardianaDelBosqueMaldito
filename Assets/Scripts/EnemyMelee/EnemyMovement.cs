using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 2f;
    public bool isChasing;

    private NavMeshAgent _agent;
    private Transform _player;
    private Animator _animator;
    private EnemyCombat _combat;

    [SerializeField] private float _stopDistance = 1.0f;
    private Vector2 _lastDirection;

    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _animator = GetComponent<Animator>();
        _combat = GetComponent<EnemyCombat>();

        // Configuración necesaria para 2D
        _agent.updateRotation = false;
        _agent.updateUpAxis = false;
        _agent.speed = speed;
    }

    void FixedUpdate()
    {
        if (isChasing && _player != null)
        {
            float distance = Vector2.Distance(transform.position, _player.position);

            if (_combat != null && _combat.isAttacking)
            {
                _agent.isStopped = true;
            }
            else if (distance >= _stopDistance)
            {
                _agent.isStopped = false;
                _agent.SetDestination(_player.position);

                Vector2 direction = (_player.position - transform.position).normalized;
                _animator.SetFloat("MovementX", direction.x);
                _animator.SetFloat("MovementY", direction.y);
                _animator.SetFloat("Movement", _agent.velocity.magnitude);

                _lastDirection = direction;
            }
            else
            {
                _agent.isStopped = true;
                _animator.SetFloat("MovementX", _lastDirection.x);
                _animator.SetFloat("MovementY", _lastDirection.y);
                _animator.SetFloat("Movement", 0f);
            }
        }
        else
        {
            _agent.isStopped = true;
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
        _agent.isStopped = true;
    }
}

