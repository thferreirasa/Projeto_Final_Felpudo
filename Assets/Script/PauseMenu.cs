using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pausePanel;

    public static bool JogoEstaPausado = false;

    public string cenaMenuInicial = "MainMenu";

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (JogoEstaPausado)
            {
                ContinuarJogo();
            } else
            {
                PausarJogo();
            }
        }
    }

    public void PausarJogo()
    {
        pausePanel.SetActive(true);

        // pausa tempo do jogo
        Time.timeScale = 0f;
        JogoEstaPausado = true;
    }

    public void ContinuarJogo()
    {
        pausePanel.SetActive(false);

        // volta tempo normal
        Time.timeScale = 1f;
        JogoEstaPausado = false;
    }

    public void VoltarAoMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(cenaMenuInicial);
    }
}
