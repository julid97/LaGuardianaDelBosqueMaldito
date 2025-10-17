using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class BulletController : MonoBehaviour
{
    private Rigidbody2D _rb;

    private Vector2 _direction;

    [SerializeField] private float _autoDestroyTime = 2;

    [SerializeField] private float _speed = 2;

    [SerializeField] private int _damage;

    private Transform _player;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();

        _player = GameObject.FindGameObjectWithTag("Player").transform;

        _direction = (_player.position - transform.position).normalized;

        _rb.linearVelocity = _direction * _speed;

        Destroy(gameObject, _autoDestroyTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();

            if (playerHealth != null)
            {
                playerHealth.ChangeHealth(_damage);
            }
            Destroy(gameObject);
        }
    }

}
