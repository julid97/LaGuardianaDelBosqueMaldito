using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovements : MonoBehaviour
{
    public float speed = 5;
    public Rigidbody2D rb;

    // Update is called once per frame
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        rb.linearVelocity = new Vector2(horizontal, vertical)*speed;
    }
}
