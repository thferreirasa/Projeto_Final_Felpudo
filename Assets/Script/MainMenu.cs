using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Lvl1_Instructions");
    }

    public void ExitGame()
    {
        Application.Quit();
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false; // Para parar no editor
#endif
    }

    public void Level1()
    {
        SceneManager.LoadScene("Lvl1_Instructions");
    }

    public void Level2()
    {
        SceneManager.LoadScene("Lvl2_Instructions");
    }

    public void Level3()
    {
        SceneManager.LoadScene("Lvl3_Instructions");
    }

    public void Level4()
    {
        SceneManager.LoadScene("Lvl4_Instructions");
    }
}
