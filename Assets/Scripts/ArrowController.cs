using UnityEngine;

public class Arrow : MonoBehaviour
{
    private Rigidbody2D _rb;

    public Vector2 direction = Vector2.right;
    
    [SerializeField] private float autoDestroyTime = 2;

    [SerializeField] private float speed = 2;

    [SerializeField] private int damage;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();

        _rb.linearVelocity = direction * speed;

        Destroy(gameObject, autoDestroyTime);
    }
 
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Enemy"))
        {
            EnemyHealth enemyHealth = collision.gameObject.GetComponent<EnemyHealth>();

            if (enemyHealth != null)
            {
               enemyHealth.Damager(damage);
            }
            Destroy(gameObject);
        }
    }
}
