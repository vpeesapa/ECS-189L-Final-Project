using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SetDifficultyOnClick : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject PlayerCity;
    Difficulty GameDifficulty = new Difficulty();
    // Update is called once per frame
    void SetDifficulty(string sceneName, string difficulty)
    {

        if (difficulty == "easy")
        {
            this.GameDifficulty.SetNumLives(5.0f);
            this.GameDifficulty.SetRestartLevel(true);
            SceneManager.LoadScene(sceneName);
        }
        else if (difficulty == "medium")
        {
            this.GameDifficulty.SetNumLives(3.0f);
            this.GameDifficulty.SetRestartLevel(false);
            SceneManager.LoadScene(sceneName);
        }
        if (difficulty == "hard")
        {
            this.GameDifficulty.SetNumLives(1.0f);
            this.GameDifficulty.SetRestartLevel(false);
            SceneManager.LoadScene(sceneName);
        }
        SceneManager.LoadScene(sceneName);
    }
    public Difficulty GetDifficulty()
    {
        return this.GameDifficulty;
    }
}
