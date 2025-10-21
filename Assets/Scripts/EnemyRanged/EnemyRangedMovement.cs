using UnityEngine;

public class EnemyRangedMovement : MonoBehaviour
{
    private Transform _player;

    private Animator _animator;

    private EnemyRangedCombat _enemy;
    void Start()
    {
        _enemy = GetComponent<EnemyRangedCombat>();

        _animator = GetComponent<Animator>();
    }
    public void SetPlayerTransform(Transform player)
    {
        _player = player;
    }

    void FixedUpdate()
    {
        if ( _enemy.isRanged && _player != null)
        {   
            Vector2 direction = (_player.position - transform.position).normalized;
         
            _animator.SetFloat("MovementX", direction.x);
            _animator.SetFloat("MovementY", direction.y);
        }



    }
}
