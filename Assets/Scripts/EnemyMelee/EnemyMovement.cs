using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 2f;

    public bool isChasing;

    private Rigidbody2D _rb;

    private Transform _player;   
      

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if (isChasing && _player != null)
        {
            Vector2 direction = (_player.position - transform.position).normalized;

            _rb.linearVelocity = direction * speed;
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