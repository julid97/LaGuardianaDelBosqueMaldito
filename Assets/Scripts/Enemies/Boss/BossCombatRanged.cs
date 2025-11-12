using UnityEngine;
using System.Collections;

public class BossCombatRanged : MonoBehaviour
{
    [Header("Ataque")]
    public Transform spellStart;
    public GameObject spellPrefab;
    public float fireTime = 1f;

    [Header("Referencias")]
    private Animator _animator;
    private bool _canShoot = true;
    private RangedRangeDetector _rangeDetector;

    void Awake()
    {
        _animator = GetComponent<Animator>();
        _rangeDetector = GetComponentInChildren<RangedRangeDetector>();
    }

    void Update()
    {
        if (_rangeDetector != null && _rangeDetector.isRanged && _canShoot)
        {
            StartCoroutine(ShootRoutine());
        }
    }

    private IEnumerator ShootRoutine()
    {
        _canShoot = false;
        _animator.SetBool("IsAttackingRanged", true);

        //  Espera hasta el frame 9 (~0.75s a 12 fps)
        yield return new WaitForSeconds(0.68f);

        //  Instancia el hechizo justo en el momento del disparo
        Instantiate(spellPrefab, spellStart.position, Quaternion.identity);

        //  Espera el resto de la animación (~0.16s)
        yield return new WaitForSeconds(0.26f);
        _animator.SetBool("IsAttackingRanged", false);

        //  Espera el tiempo de recarga antes del siguiente disparo
        yield return new WaitForSeconds(fireTime);
        _canShoot = true;
    }
}
