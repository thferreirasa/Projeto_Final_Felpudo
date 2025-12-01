using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerLvl2 : MonoBehaviour
{
    Rigidbody2D corpoJogador;
    private Animator animator;
    bool comecou;
    bool acabou;
    Vector2 forcaImpulso = new Vector2(0, 250f);

    void Start()
    {
        animator = GetComponent<Animator>();
        corpoJogador = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // pular
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            if (!comecou)
            {
                comecou = true;
                corpoJogador.isKinematic = false;
            }

            if (animator != null)
            {
                animator.SetTrigger("Pular");
            }

            corpoJogador.velocity = new Vector2(0, 0);
            corpoJogador.AddForce(forcaImpulso);
        }
    }
}
