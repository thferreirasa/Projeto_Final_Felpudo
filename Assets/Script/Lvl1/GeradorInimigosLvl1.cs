using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeradorInimigosLvl1 : MonoBehaviour
{
    // prefab do inimigo
    public GameObject inimigoPrefab;
    public float intervalo = 3f;

    // Limite de spawn no eixo X (à direita da tela)
    public float limiteX = 8f;

    // Posição y fixa
    public float yFixo = -1.69f;

    // Velocidade de movimento dos inimigos
    public float velocidade = 3f;

    // Limite X para destruir o inimigo ao sair da tela
    public float limiteDestruicaoX = -12f;

    void Start()
    {
        InvokeRepeating("GerarInimigo", 0f, intervalo);
    }

    void GerarInimigo()
    {
        // define posição de spawn
        float x = limiteX;

        // valor fixo de Y
        float y = yFixo;

        Vector2 posicaoSpawn = new Vector2(x, y);

        // Instancia o inimigo
        GameObject inimigo = Instantiate(inimigoPrefab, posicaoSpawn, Quaternion.identity);

        // Inicia o movimento automático (corrotina)
        StartCoroutine(MoverInimigo(inimigo));
    }

    IEnumerator MoverInimigo(GameObject inimigo)
    {
        while (inimigo != null)
        {
            // Move o inimigo da direita para a esquerda
            inimigo.transform.Translate(Vector2.left * velocidade * Time.deltaTime);

            // Se o inimigo sair do limite visível, destrói o objeto
            if (inimigo.transform.position.x < limiteDestruicaoX)
            {
                Destroy(inimigo);
                yield break; // Sai da corrotina
            }
            yield return null; // Espera o próximo frame
        }
    }
}
