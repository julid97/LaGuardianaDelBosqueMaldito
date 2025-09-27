using UnityEngine;

public class Arrow : MonoBehaviour
{
    private Rigidbody2D _rb;

    public Vector2 direction = Vector2.right;
    
    [SerializeField] private float autoDestroyTime = 2;

    [SerializeField] private float speed = 2;




    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();

        _rb.linearVelocity = direction * speed;

        Destroy(gameObject, autoDestroyTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
