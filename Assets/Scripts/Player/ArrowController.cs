using UnityEngine;

public class ArrowController : MonoBehaviour
{
    private Rigidbody2D _rb;

    public Vector2 direction = Vector2.right;
    
    [SerializeField] private float _autoDestroyTime = 3;

    [SerializeField] private float _speed = 2;

    [SerializeField] private int _damage;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();

        transform.right = direction;


        _rb.linearVelocity = transform.right * _speed;

        Destroy(gameObject, _autoDestroyTime);
    }
 
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Enemy"))
        {
            EnemyHealth enemyHealth = collision.gameObject.GetComponent<EnemyHealth>();

            if (enemyHealth != null)
            {
               enemyHealth.Damager(_damage);
            }
            Destroy(gameObject);
        }
    }
}
