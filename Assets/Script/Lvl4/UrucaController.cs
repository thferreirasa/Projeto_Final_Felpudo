using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UrucaController : MonoBehaviour
{
    public int vidaAtual = 3;
    private Animator animator;

    public Transform alvo;
    public float velocidade;
    private Rigidbody2D corpoUruca;

    // Start is called before the first frame update
    void Start()
    {
        corpoUruca = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        Vector2 direcao = (alvo.position - transform.position).normalized;

        direcao.y = 0;

        corpoUruca.velocity = direcao * velocidade;

        // giro
        if (corpoUruca.velocity.x > 0.1f)
        {
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        } else if (corpoUruca.velocity.x < -.1f)
        {
            transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }
    }

    public void TomarDano(int dano)
    {
        vidaAtual -= dano;

        if (vidaAtual <= 0)
        {
            Morrer();
        }
    }

    void Morrer()
    {
        if (animator != null)
        {
            animator.SetTrigger("Derrota");
        }

        // desativar colisor e movimento
        GetComponent<Collider2D>().enabled = false;
        GetComponent<UrucaController>().enabled = false;

        if (GameManagerLvl4.instance != null)
        {
            GameManagerLvl4.instance.GameVictory();
        }

        Destroy(gameObject, 0.5f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (GameManagerLvl4.instance != null)
            {
                GameManagerLvl4.instance.PerdeVida();
            }
        }
    }
}
