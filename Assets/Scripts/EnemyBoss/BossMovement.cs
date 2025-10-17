using UnityEngine;

public class BossMovement : MonoBehaviour
{
    public float speed = 2f;

    private Transform _player;

    [HideInInspector] public bool isRange;

    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if (isRange && _player != null) 
        {
            Vector3 target = new Vector3(_player.position.x, transform.position.y, transform.position.z);

            transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
        }
    }
}