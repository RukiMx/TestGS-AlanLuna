using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleFactory
{
    public static GameObject CreateObstacle(GameObject prefab)
    {
        GameObject obstacle = GameObject.Instantiate(prefab);
        obstacle.GetComponent<IObstacle>().Spawn();
        return obstacle;
    }
}
