using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public Vector2 spawnRangeX;
    public Vector2 spawnRangeY;

    public float spawnRate = 1.5f;

    #region UNITY METHODS
    private void Start()
    {
        InvokeRepeating(nameof(SpawnObstacle), 1f, spawnRate);
    }
    #endregion

    private void SpawnObstacle()
    {
        float randomX = Random.Range(spawnRangeX.x, spawnRangeX.y);
        float randomY = Random.Range(spawnRangeY.x, spawnRangeY.y);
        Vector3 spawnPosition = new Vector3(randomX, randomY, 0f);

        PoolManager.Instance.GetObject("Square", spawnPosition, Quaternion.identity).GetComponent<FallingObstacle>().Spawn();//SetActive(true) ;
    }
}