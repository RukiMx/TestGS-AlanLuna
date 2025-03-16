using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public static class GameEvents
{
    public static Action OnGamePaused;
    public static Action OnGameResumed;
    public static Action<int> OnHealthChanged;
    public static Action OnPlayerDead;
}
