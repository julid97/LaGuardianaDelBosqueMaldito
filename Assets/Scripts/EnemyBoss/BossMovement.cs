using UnityEngine;

public class BossMovement : MonoBehaviour
{
    public float speed = 2f;

    private Transform _player;

    [HideInInspector] public bool isRange;

    private Animator _animator;

    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player").transform;

        _animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (isRange && _player != null) 
        {
            Vector3 target = new Vector3(_player.position.x, transform.position.y, transform.position.z);

            transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
            float directionX = _player.position.x - transform.position.x;
            if (directionX > 0.05f)
            {
                _animator.SetFloat("Movement", directionX * speed);
            }
            else if (directionX < 0.05f)
            {
                _animator.SetFloat("Movement", directionX*speed);
            }
            else
            {
                _animator.SetFloat("Movement", 0);
                Debug.Log($"se dejo de mover: {directionX}");
            }
        }
    }
}