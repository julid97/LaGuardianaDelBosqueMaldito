using UnityEngine;

public class EnemyRangedCombat : MonoBehaviour
{
    public Transform bulletStart;

    public GameObject bulletPrefab;

    public bool isRanged;

    public float fireTime;

    private float fireRate;

    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }
    void Update()
    {
       if(Time.time >= fireRate)
        {
            Shoot();
            fireRate = Time.time + fireTime;
        }
    }

    private void Shoot()
    {
        if (isRanged)
        {
            Instantiate(bulletPrefab, bulletStart.position, Quaternion.identity);

            _animator.SetBool("IsAttacking", true);
        }
        else
        {
            _animator.SetBool("IsAttacking", false);
        }
    }
}
