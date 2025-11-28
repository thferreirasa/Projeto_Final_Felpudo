using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerLvl2 : MonoBehaviour
{
    Rigidbody2D corpoJogador;
    private Animator animator;

    void Start()
    {
        corpoJogador = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            // pular
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // colisao com inimigos
        if (other.CompareTag("Enemy"))
        {
            if (GameManagerLvl2.instance != null)
            {
                GameManagerLvl2.instance.PerdeVida();
            }

            Destroy(other.gameObject);
        }
    }
}
