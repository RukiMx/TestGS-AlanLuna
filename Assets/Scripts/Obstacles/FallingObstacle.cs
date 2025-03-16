using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingObstacle : MonoBehaviour, IObstacle
{
    public void Spawn()
    {
        //Here some configs at spawn time.
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        gameObject.SetActive(true);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Floor") || collision.gameObject.CompareTag("Player"))
        {
            gameObject.SetActive(false);
        }
            
    }
}
