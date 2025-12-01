using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameManagerLvl1 : MonoBehaviour
{
    // permite chamar o script em outros
    public static GameManagerLvl1 instance;

    public int vidas = 3;
    public string proximaCena = "Lvl2_Instructions";
    public Image[] iconesVida;

    private void Start()
    {
        // zera UI ao iniciar o jogo
        CoracoesHUD();
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
        // depois de derrotar 10 inimigos

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
}
