using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class InputManager : MonoBehaviour
{
    public static InputManager Instance { get; private set; }

    public Action<float> OnMove;
    public Action OnJump;

    #region UNITY METHODS
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

    }
    #endregion

    public void MoveLeft() => OnMove?.Invoke(-1f);
    public void MoveRight() => OnMove?.Invoke(1f);
    public void StopMove() => OnMove?.Invoke(0f);
    public void Jump() => OnJump?.Invoke();
}
