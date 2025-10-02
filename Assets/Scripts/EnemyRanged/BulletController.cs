using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class BulletController : MonoBehaviour
{
    private Rigidbody2D _rb;

    private Vector2 direction;

    [SerializeField] private float autoDestroyTime = 2;

    [SerializeField] private float speed = 2;

    [SerializeField] private int damage;

    private Transform _player;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();

        _player = GameObject.FindGameObjectWithTag("Player").transform;

        direction = (_player.position - transform.position).normalized;

        _rb.linearVelocity = direction * speed;

        Destroy(gameObject, autoDestroyTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();

            if (playerHealth != null)
            {
                playerHealth.ChangeHealth(damage);
            }
            Destroy(gameObject);
        }
    }

}
