using UnityEngine;

public class ControlaJogadorFlutuante : MonoBehaviour
{
    bool comecou;
    Rigidbody2D corpoJogador;
    public float velocidadeMovimento = 5f;

    void Start()
    {
        corpoJogador = GetComponent<Rigidbody2D>();

        // desativa gravidade
        corpoJogador.gravityScale = 0f;
    }

    void Update()
    {
        // começa o jogo ao clicar em qualquer tecla
        if (!comecou)
        {
            if (Input.anyKeyDown)
            {
                comecou = true;
            }
            return;
        }

        // direção vertical: 1 cima, -1 baixo, 0 parado
        float direcaoVertical = 0f;

        // subida
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            direcaoVertical = 1f;
        }

        // descida
        else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            direcaoVertical = -1f;
        }

        // movimento, velocidade, direção
        Vector2 novaVelocidade = new Vector2(0, direcaoVertical * velocidadeMovimento);
        corpoJogador.velocity = novaVelocidade;
    }

    
    private void OnTriggerEnter2D(Collider2D other)
    {
        // colisao com inimigos
        if (other.CompareTag("Enemy"))
        {
            if (GameManagerLvl3.instance != null)
            {
                GameManagerLvl3.instance.PerdeVida();
            }

            // destroi o inimigo
            Destroy(other.gameObject);
        }

        // colisao com frutas
        if (other.CompareTag("Fruit"))
        {
            FrutaColeta frutaScript = other.GetComponent<FrutaColeta>();
            if (GameManagerLvl3.instance != null)
            {
                GameManagerLvl3.instance.ColetarFruta();
            }

            frutaScript.Coleta();
        }
    }
}