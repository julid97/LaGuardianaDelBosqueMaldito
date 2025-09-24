using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed;

    public bool isChasing;

    private Rigidbody2D _rb;

    private Transform _player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isChasing == true)
        {
            Vector2 direction = (_player.position - transform.position).normalized;
            _rb.linearVelocity = direction * speed;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player") {
            if (_player == null) {

                _player = collision.transform;
            }
            
            isChasing = true;
        }
        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            _rb.linearVelocity = Vector2.zero;
            isChasing = false;
        }
    }
}
