using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseHandler : MonoBehaviour
{
    private bool _isPaused;

    public void OnPauseButtonPressed()
    {
        if(!_isPaused)
        {
            PauseGame();
        }
        else
        {
            ResumeGame();
        }
    }

    
    public void PauseGame()
    {
        Time.timeScale = 0;
        GameEvents.OnGamePaused?.Invoke();
        _isPaused = true;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        GameEvents.OnGameResumed?.Invoke();
        _isPaused = false;
    }
}
