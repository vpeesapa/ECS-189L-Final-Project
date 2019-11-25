using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ExitOnClick : MonoBehaviour
{
    public void ExitGame()
    {
        // To quit applications use - Application.Quit();.
        // To quit from the editor use the following.
        EditorApplication.isPlaying = false;
    }
}