using UnityEngine;

public class EnemyRangedCombat : MonoBehaviour
{
    public Transform bulletStart;

    public GameObject bulletPrefab;

    public bool isRanged;

    public float fireTime;

    private float fireRate;
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
        }
    }
}
