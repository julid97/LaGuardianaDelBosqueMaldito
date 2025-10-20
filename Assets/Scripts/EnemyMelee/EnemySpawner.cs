using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;

    public  Vector2[] spawnPos;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for (int i = 0; i < spawnPos.Length; i++)
        { 
            Vector3 pos = new Vector3(spawnPos[i].x, spawnPos[i].y, 0f);
            Instantiate(enemyPrefab, pos, Quaternion.identity);
        }

    }
}
