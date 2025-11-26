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


    void Start()
    {
        corpoJogador = GetComponent<Rigidbody2D>();

        // mostra numero de mortes 0/10 no inicio
        if (killCountText != null )
        {
            killCountText.text = numeroMortes.ToString() + " / " + mortesVitoria.ToString();
        }
    }

    void Update()
    {
        // tecla E ataca
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

            // destroi o inimigo
            Destroy(other.gameObject);
        }
    }

    void Atacar()
    {
        // animacao de ataque

        // usa o raio de ataque
        Collider2D[] inimigosAtingidos = Physics2D.OverlapCircleAll(
            transform.position,
            raioDeAtaque,
            layerInimigo
        );

        // mata inimigo
        foreach (Collider2D inimigo in inimigosAtingidos)
        {
            Destroy(inimigo.gameObject);
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