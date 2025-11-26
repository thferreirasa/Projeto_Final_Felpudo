using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrutaColeta : MonoBehaviour
{
    private Animator animator;
    private Collider2D colisor;

    private void Start()
    {
        animator = GetComponent<Animator>();
        colisor = GetComponent<Collider2D>();
    }

    public void Coleta()
    {
        animator.SetTrigger("Coletada");

        if (colisor != null)
        {
            colisor.enabled = false;
        }

        // destroi animacao
        Destroy(gameObject, 0.5f);
    }
}
