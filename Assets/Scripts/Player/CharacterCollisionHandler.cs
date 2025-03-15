using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CharacterCollisionHandler : MonoBehaviour
{
    private CharacterMove _characterMove;
    private HealthSystem _healthSystem;

    public Action OnGroundTouch;
    public Action OnGroundExit;
    public Action OnObstacleHit;

    #region UNITY METHODS
    private void Awake()
    {
        _healthSystem = GetComponent<HealthSystem>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            OnObstacleHit?.Invoke();
        }
        else if (collision.gameObject.CompareTag("Floor"))
        {
            OnGroundTouch?.Invoke();
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            OnGroundExit?.Invoke();
        }
    }
    #endregion
}
