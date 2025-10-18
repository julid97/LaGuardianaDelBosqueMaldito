using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 2f;

    public bool isChasing;

    private Rigidbody2D _rb;

    private Transform _player;
    //test animacion 
    private Animator _animator;
    private Vector2 _lastDirection;


    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        //test animacion
        _animator = GetComponent<Animator>();
    }
    void Update()
    {
        if (isChasing && _player != null)
        {
            Vector2 direction = (_player.position - transform.position).normalized;

            _rb.linearVelocity = direction * speed;
            //test animacion - Enviar direccion al animator
            _animator.SetFloat("MovementX", direction.x);
            _animator.SetFloat("MovementY", direction.y);
            _animator.SetFloat("Movement", direction.magnitude);
            //personaje quedara en posicion que deja de caminar
            if (direction.magnitude > 0.01f)
            {
                _lastDirection = direction;
            }
            else
            {//detener movimiento
                _rb.linearVelocity = Vector2.zero;
                //mantener ultima direccion mirada
                _animator.SetFloat("MovementX", _lastDirection.x);
                _animator.SetFloat("MovementY", _lastDirection.y);
                _animator.SetFloat("Movement", 0f);

            }
        }
    }

    public void SetPlayerTransform(Transform player)
    {
        _player = player;
    }

    public void StopChasing()
    {
        _player = null;

        _rb.linearVelocity = Vector2.zero;
    }
}