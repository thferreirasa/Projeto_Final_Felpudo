using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerParticles : MonoBehaviour
{
    public ParticleSystem coracoesParticulas;
    private bool hasTriggered = false;

    public GameObject menuButton;

    private void Start()
    {
        if (coracoesParticulas != null)
        {
            coracoesParticulas.Stop();
        }

        if (menuButton != null)
        {
            menuButton.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!hasTriggered && collision.CompareTag("Player"))
        {
            if (PlayerControllerCinematic.instance  != null)
            {
                PlayerControllerCinematic.instance.enabled = false;

                Rigidbody2D rb = collision.GetComponent<Rigidbody2D>();

                if (rb  != null )
                {
                    rb.velocity = Vector2.zero;
                }

                // parar animacao walk
                Animator playerAnimator = collision.GetComponent<Animator>();

                if (playerAnimator != null)
                {
                    playerAnimator.SetBool("Andar", false);
                }
            }

            if (coracoesParticulas != null)
            {
                coracoesParticulas.Play();
            }

            if (menuButton != null)
            {
                menuButton.SetActive(true);
            }

            hasTriggered = true;

            GetComponent<Collider2D>().enabled = false;
        }
    }
}
