using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// ACTUALLY IT CAN BE SCORE CLASS (SINGLETON)
// THEN ONLY CREATED ONE TIME ENTIRE GAME.
public class ScoreComponent : MonoBehaviour
{
    public static int score = 0;

    public void Increament()
    {
        score += 1;
    }

    public void ResetScore()
    {
        score = 0;
    }

    public int GetScore()
    {
        return score;
    }
}
