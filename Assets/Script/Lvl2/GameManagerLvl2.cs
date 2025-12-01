using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Rendering;

public class GameManagerLvl2 : MonoBehaviour
{
    // permite chamar o script em outros
    public static GameManagerLvl2 instance;

    public int vidas = 3;
    public string proximaCena = "Lvl3_Instructions";
    public Image[] iconesVida;

    public Image gasolinaBarra;
    public float gasolinaMaxima = 100f;
    public float taxaConsumoGasolina = 2f;

    private float gasolinaAtual;

    private void Start()
    {
        gasolinaAtual = gasolinaMaxima;

        // zera UI ao iniciar o jogo
        CoracoesHUD();
        AtualizarGasolinaHUD();
    }

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        if (gasolinaAtual > 0)
        {
            gasolinaAtual -= taxaConsumoGasolina + Time.deltaTime;

            // valor minimo 0
            gasolinaAtual = Mathf.Max(0, gasolinaAtual);

            AtualizarGasolinaHUD();
        }

        if (gasolinaAtual <= 0)
        {
            Morrer();
        }
    }

    public void PerdeVida()
    {
         vidas--;

         // atualizar HUD vidas
         CoracoesHUD();

         if (vidas <= 0)
         {
             Morrer();
         }
    }

    void Morrer()
    {
         // reseta vidas
         vidas = 3;

         // recarrega a cena atual
         SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }


    public void GameVictory()
    {
         // proxima cena
         SceneManager.LoadScene(proximaCena);
    }

    // esconder coracoes com perda de vida
    public void CoracoesHUD()
    {
         // loop percorre array de coracoes
         for (int i = 0; i < iconesVida.Length; i++)
         {
             if (i < vidas)
             {
                 iconesVida[i].gameObject.SetActive(true);
             }
             else
             {
                 iconesVida[i].gameObject.SetActive(false);
             }
         }
    }

    void AtualizarGasolinaHUD()
    {
        float fillAmount = gasolinaAtual / gasolinaMaxima;

        gasolinaBarra.fillAmount = fillAmount;
    }

    public void Reabastecer(float valor)
    {
        gasolinaAtual += valor;

        // valor max
        gasolinaAtual = Mathf.Min(gasolinaMaxima, gasolinaAtual);

        AtualizarGasolinaHUD();
    }
}
