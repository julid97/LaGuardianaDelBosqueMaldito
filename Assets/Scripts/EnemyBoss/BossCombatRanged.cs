using UnityEngine;

public class BossCombatRanged : MonoBehaviour
{
    public Transform spellStart;

    public GameObject spellPrefab;

    public float fireTime;


    private float _fireRate;

    void OnEnable()
    {
        _fireRate = Time.time + fireTime;
    }
    void Update()
    {
        if (Time.time >= _fireRate)
        {
            Instantiate(spellPrefab, spellStart.position, Quaternion.identity);
            _fireRate = Time.time + fireTime;
        }
    }
    }