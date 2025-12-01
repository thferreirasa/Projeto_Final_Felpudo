using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameManagerLvl4 : MonoBehaviour
{
    public static GameManagerLvl4 instance;
    public int vidas = 3;
    public string proximaCena = "CinematicFinal";
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
        // proxima cena
        SceneManager.LoadScene(proximaCena);
    }

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
