using UnityEngine;

public class BossMovement : MonoBehaviour
{
    public float speed = 2f;
    private Transform _player;
    private Animator _animator;
    [HideInInspector] public bool isRange;

    private BossCombatMelee _combat;

    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player").transform;
        _animator = GetComponent<Animator>();
        _combat = GetComponent<BossCombatMelee>();
    }

    void Update()
    {
        if (_player == null || !isRange)
        {
            _animator.SetFloat("Movement", 0);
            return;
        }

        if (_combat != null && _combat.isAttackingMelee)
        {
            _animator.SetFloat("Movement", 0);
            return;
        }

        // Movimiento hacia el jugador
        Vector3 target = new Vector3(_player.position.x, transform.position.y, transform.position.z);
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);

        float directionX = _player.position.x - transform.position.x;
        float normalizedDir = Mathf.Clamp(directionX * 10f, -1f, 1f);
        _animator.SetFloat("Movement", normalizedDir);

        // Si esta muy cerca
        if (Mathf.Abs(directionX) < 0.05f)
            _animator.SetFloat("Movement", 0);
    }
}
