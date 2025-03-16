using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] private Vector2 _spawnRangeX;
    [SerializeField] private Vector2 _spawnRangeY;

    public float spawnRate = 1.5f;

    #region UNITY METHODS
    private void Start()
    {
        InvokeRepeating(nameof(SpawnObstacle), 1f, spawnRate);
    }
    #endregion

    private void SpawnObstacle()
    {
        float randomPosX = Random.Range(_spawnRangeX.x, _spawnRangeX.y);
        float randomPosY = Random.Range(_spawnRangeY.x, _spawnRangeY.y);
        Vector3 spawnPosition = new Vector3(randomPosX, randomPosY, 0f);

        PoolManager.Instance.GetObject("Square", spawnPosition, Quaternion.identity).GetComponent<FallingObstacle>().Spawn();//SetActive(true) ;
    }
}