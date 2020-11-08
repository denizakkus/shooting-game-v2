using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameOverUtility
{
    public static System.Action onGameOver;

    public static void GameOver()
    {
        onGameOver?.Invoke();
    }

    public static void AddOnGameOverListener(System.Action listener)
    {
        onGameOver += listener;
    }
}
