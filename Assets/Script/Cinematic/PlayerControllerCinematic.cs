using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerCinematic : MonoBehaviour
{
    bool comecou;
    bool acabou;

    Rigidbody2D corpoJogador;
    private Animator animator;
    public float velocidadeMovimento = 5f;
    private float direcaoHorizontal = 0;
    private float escalaOriginalX;
    public static PlayerControllerCinematic instance;

    private void Awake()
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
    void Start()
    {
        corpoJogador = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        escalaOriginalX = Mathf.Abs(transform.localScale.x);
    }

    // Update is called once per frame
    void Update()
    {
        // movimentacao
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            direcaoHorizontal = 1f;
        }
        else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            direcaoHorizontal = -1f;
        }
        else
        {
            direcaoHorizontal = 0f;
        }
    }

    void FixedUpdate()
    {
        corpoJogador.velocity = new Vector2(direcaoHorizontal * velocidadeMovimento, corpoJogador.velocity.y);

        Flip(direcaoHorizontal);

        if (animator != null)
        {
            bool isMoving = Mathf.Abs(corpoJogador.velocity.x) > 0.1f;
            animator.SetBool("Andar", isMoving);
        }
    }

    void Flip(float direcao)
    {
        if (direcaoHorizontal != 0)
        {
            if (direcaoHorizontal > 0)
            {
                // inverte sprite no eixo X
                transform.localScale = new Vector3(escalaOriginalX, transform.localScale.y, transform.localScale.z);
            }
            else if (direcaoHorizontal < 0)
            {
                transform.localScale = new Vector3(-escalaOriginalX, transform.localScale.y, transform.localScale.z);
            }
        }
    }
}
