using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class PlayerControllerLvl4 : MonoBehaviour
{
    bool comecou;
    bool acabou;

    Rigidbody2D corpoJogador;
    private Animator animator;
    public float velocidadeMovimento = 5f;
    private float direcaoHorizontal = 0;
    private float escalaOriginalX;
    public float forcaPulo = 8f;

    public float raioDeAtaque = 1.0f;
    public LayerMask layerInimigo;

    public int danoAplicado = 1;

    // pode ser acessado de outros scripts
    public static PlayerControllerLvl4 Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
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
        } else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            direcaoHorizontal = -1f;
        } else
        {
            direcaoHorizontal = 0f;
        }

        // pulo
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (!comecou)
            {
                comecou = true;
                corpoJogador.isKinematic = false;
            }

            corpoJogador.velocity = new Vector2(corpoJogador.velocity.x, 0);
            corpoJogador.AddForce(Vector2.up * forcaPulo, ForceMode2D.Impulse);

            if (animator != null)
            {
                animator.SetTrigger("Pular");
            }
        }

        // ataque
        if (Input.GetKeyDown(KeyCode.E))
        {
            Atacar();
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

     void OnTriggerEnter2D(Collider2D other)
     {
         // colisao com inimigos
         if (other.CompareTag("Enemy"))
         {
             if (GameManagerLvl1.instance != null)
             {
                 GameManagerLvl1.instance.PerdeVida();
             }

             Destroy(other.gameObject);
         }
     }

     void Atacar()
     {
         // animacao de ataque do jogador
         if (animator != null)
         {
             animator.SetTrigger("Atacar");
         }

         int danoAplicado = 1;

         // usa o raio de ataque
         Collider2D[] inimigosAtingidos = Physics2D.OverlapCircleAll(
             transform.position,
             raioDeAtaque,
             layerInimigo
         );

         foreach (Collider2D inimigo in inimigosAtingidos)
         {
             UrucaController uruca = inimigo.GetComponent<UrucaController>();

             if (uruca != null)
             {
                 uruca.TomarDano(danoAplicado);
             }
         }
     }

     void OnDrawGizmosSelected()
     {
         if (raioDeAtaque <= 0f)
             return;

         Gizmos.color = Color.red;

         Gizmos.DrawWireSphere(transform.position, raioDeAtaque);
     }
}
