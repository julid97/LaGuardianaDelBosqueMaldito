using System.Collections;
using UnityEngine;
using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;

public class EnemyRangedCombat : MonoBehaviour
{
    public Transform bulletStart;

    public GameObject bulletPrefab;

    public bool isRanged;

    public float fireTime;

    private Animator _animator;

    private bool _canShoot = true;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }
    void Update()
    {
        if (isRanged && _canShoot)
        {
            StartCoroutine(ShootRoutine());
        }
    }

    private IEnumerator ShootRoutine()
    {
        _canShoot = false;

        _animator.SetBool("IsAttacking", true);

        // Dispara en el frame 4
        yield return new WaitForSeconds(0.66f);

        Instantiate(bulletPrefab, bulletStart.position, Quaternion.identity);

        //espera a que termine la animacion(1s total 0.66f + 0.34f)
        yield return new WaitForSeconds(0.34f);

        _animator.SetBool("IsAttacking", false);

        //Espera el tiempo entre disparos para poder volver a disparar
        yield return new WaitForSeconds(fireTime);

        _canShoot = true;

    }
    private void Shoot()
    {
        if (isRanged)
        {
            

            _animator.SetBool("IsAttacking", true);
        }
        else
        {
            _animator.SetBool("IsAttacking", false);
        }
    }
}
