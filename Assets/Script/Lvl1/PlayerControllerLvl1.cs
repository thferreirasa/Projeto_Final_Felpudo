using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerControllerLvl1 : MonoBehaviour
{
    bool comecou;
    Rigidbody2D corpoJogador;

    public float raioDeAtaque = 1.0f;
    public LayerMask layerInimigo;
    public string proximaCena = "Level2";
    public TMPro.TextMeshProUGUI killCountText;
    public int mortesVitoria = 10;
    int numeroMortes = 0;

    private Animator animator;


    void Start()
    {
        corpoJogador = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        if (killCountText != null)
        {
            killCountText.text = numeroMortes.ToString() + " / " + mortesVitoria.ToString();
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Atacar();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
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

        // usa o raio de ataque
        Collider2D[] inimigosAtingidos = Physics2D.OverlapCircleAll(
            transform.position,
            raioDeAtaque,
            layerInimigo
        );

        // mata inimigo
        foreach (Collider2D inimigo in inimigosAtingidos)
        {
            Animator inimigoAnimator = inimigo.GetComponent<Animator>();

            if (inimigoAnimator != null)
            {
                inimigoAnimator.SetTrigger("Derrota");

                Destroy(inimigo.gameObject, 0.3f);
            }
            else
            {
                Destroy(inimigo.gameObject);
            }

            ContarMorte();
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (raioDeAtaque <= 0f)
            return;

        Gizmos.color = Color.red;

        Gizmos.DrawWireSphere(transform.position, raioDeAtaque);
    }

    public void ContarMorte()
    {
        numeroMortes++;

        if (killCountText != null)
        {
            killCountText.text = numeroMortes.ToString() + " / " + mortesVitoria.ToString();
        }

        if (numeroMortes >= mortesVitoria)
        {
            // carregar cena
            SceneManager.LoadScene(proximaCena);
        }
    }
}