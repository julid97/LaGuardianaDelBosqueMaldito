using UnityEngine;

public class BulletController : MonoBehaviour
{
    private Rigidbody2D _rb;

    private Vector2 _direction;

    [SerializeField] private float _autoDestroyTime = 2;

    [SerializeField] private float _speed = 2;

    [SerializeField] private int _damage;

    private GameObject _player;
    private Transform _playerTransform;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();

        _player = GameObject.FindGameObjectWithTag("Player");

        if (_player == null) return;

        _playerTransform = _player.transform;

        _direction = (_playerTransform.position - transform.position).normalized;

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
                playerHealth.LoseHealth(_damage);
            }
            Destroy(gameObject);
        }
    }

}
