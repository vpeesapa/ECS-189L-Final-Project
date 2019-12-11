using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Difficulty
{
    private float NumLives;
    private bool RestartLevel;

    public void SetNumLives(float Numlives)
    {
        this.NumLives = Numlives;
    }
    public float GetNumLives()
    {
        return this.NumLives;
    }
    public void SetRestartLevel(bool Restartlevel)
    {
        this.RestartLevel = Restartlevel;
    }
    public bool GetRestartLevel()
    {
        return this.RestartLevel;
 
    }
}
