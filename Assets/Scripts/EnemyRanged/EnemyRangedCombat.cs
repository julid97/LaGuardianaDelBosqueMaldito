using UnityEngine;

public class EnemyRangedCombat : MonoBehaviour
{
    public Transform bulletStart;

    public GameObject bulletPrefab;

    public bool isRanged;

    public float fireTime;

    private float _fireRate;
    void Update()
    {
       if(Time.time >= _fireRate)
        {
            Shoot();
            _fireRate = Time.time + fireTime;
        }
    }

    private void Shoot()
    {
        if (isRanged)
        {
            Instantiate(bulletPrefab, bulletStart.position, Quaternion.identity);
        }
    }
}
