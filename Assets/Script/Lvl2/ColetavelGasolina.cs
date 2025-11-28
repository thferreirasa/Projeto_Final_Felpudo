using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColetavelGasolina : MonoBehaviour
{
    public float valorGasolina = 25f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GameManagerLvl2.instance.Reabastecer(valorGasolina);
        }

        Destroy(gameObject);
    }
}
