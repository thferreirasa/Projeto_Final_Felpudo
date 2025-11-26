using UnityEngine;

public class PlayerControllerLvl1 : MonoBehaviour
{
    bool comecou;
    Rigidbody2D corpoJogador;

    public float raioDeAtaque = 1.0f;
    public LayerMask layerInimigo;

    void Start()
    {
        corpoJogador = GetComponent<Rigidbody2D>();
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
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (raioDeAtaque <= 0f)
            return;

        Gizmos.color = Color.red;

        Gizmos.DrawWireSphere(transform.position, raioDeAtaque);
    }
}