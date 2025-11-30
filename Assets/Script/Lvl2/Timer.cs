using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public float timeLeft = 60f;
    public TMP_Text timerText;
    public Color normalColor = Color.white;
    public Color warningColor = Color.red;
    public float warningTime = 10f;

    public string proximaCena = "Level3";

    private bool isGameOver = false;

    private void Start()
    {
        Time.timeScale = 1f; // garante que o jogo comece rodando normal
    }

    void Update()
    {
        if (isGameOver)
            return;

        timeLeft -= Time.deltaTime;

        if (timeLeft <= 0)
        {
            timeLeft = 0;
            isGameOver = true;

            SceneManager.LoadScene(proximaCena);
        }

        if (timerText != null)
        {
            timerText.text = "Time: " + Mathf.Ceil(timeLeft).ToString();

            // muda a cor se estiver perto do fim
            if (timeLeft <= warningTime)
            {
                float t = Mathf.PingPong(Time.time * 5f, 1f);
                timerText.color = Color.Lerp(normalColor, warningColor, t);
            }
            else
            {
                timerText.color = normalColor;
            }
        }
    }
}

