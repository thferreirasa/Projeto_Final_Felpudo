using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameManagerLvl3 : MonoBehaviour
{
    // permite chamar o script em outros
    public static GameManagerLvl3 instance;

    public int vidas = 3;
    public int frutasColetadas = 0;
    public int frutasVitoria = 5;
    public string proximaCena = "Lvl4_Instructions";
    public Image[] iconesVida;
    public TextMeshProUGUI contadorFrutasTexto;


    private void Start()
    {
        // zera UI ao iniciar o jogo
        CoracoesHUD();
        AtualizaFrutasUI();
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

    public void ColetarFruta()
    {
        frutasColetadas++;

        // atualiza o contador de frutas na hud
        AtualizaFrutasUI();

        if (frutasColetadas >= frutasVitoria)
        {
            GameVictory();
        }
    }

    public void GameVictory()
    {
        // reseta contagem de frutas
        frutasColetadas = 0;

        AtualizaFrutasUI();

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

    public void AtualizaFrutasUI()
    {
        contadorFrutasTexto.text = frutasColetadas.ToString() + " / " + frutasVitoria.ToString();
    }
}