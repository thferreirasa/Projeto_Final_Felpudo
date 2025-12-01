using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InstructionsScreen : MonoBehaviour
{
    public string nextLevel;
    // Start is called before the first frame update
    public void PlayGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(nextLevel);
    }
}