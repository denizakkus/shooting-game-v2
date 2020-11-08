using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverComponent : MonoBehaviour
{
    [SerializeField] private UnityEngine.Events.UnityEvent onGameOver;

    private void Awake()
    {
        GameOverUtility.AddOnGameOverListener( ()=> { onGameOver?.Invoke(); } );
    }

    public void OnGameOver()
    {
        GameOverUtility.GameOver();
    }
}
