using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UrucaController : MonoBehaviour
{
    public int vidaAtual = 3;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void TomarDano(int dano)
    {
        vidaAtual -= dano;

        if (vidaAtual < 0)
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

        Destroy(gameObject, 0.5f);

        // chamar tela de vitoria/cinematic
    }
}
