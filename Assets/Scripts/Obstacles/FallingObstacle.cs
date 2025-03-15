using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingObstacle : MonoBehaviour, IObstacle
{
    public void Spawn()
    {
        //transform.position = new Vector3(Random.Range(-8f, 8f), 6f, 0);
        gameObject.SetActive(true);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Floor") || collision.gameObject.CompareTag("Player"))
            gameObject.SetActive(false);
    }
}
