using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveFundo : MonoBehaviour
{
    SpriteRenderer grafico;
    void Start()
    {
        grafico = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        float offset = Time.time * 0.4f;
        grafico = GetComponent<SpriteRenderer>();
        grafico.material.SetTextureOffset("_MainTex", new Vector2(offset, 0));
    }
}
