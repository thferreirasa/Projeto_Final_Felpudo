using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MoveTilemap : MonoBehaviour
{
    // ⚠️ Se o seu material usar uma propriedade diferente de _MainTex, mude o nome aqui.
    private static readonly int MainTex = Shader.PropertyToID("_MainTex");

    // O valor que controla a velocidade do movimento
    public float velocidadeMovimento = 0.4f;

    // O Renderer do Tilemap
    private TilemapRenderer tilemapRenderer;

    void Start()
    {
        // Pega o componente TilemapRenderer
        tilemapRenderer = GetComponent<TilemapRenderer>();

        // ⚠️ Nota: No Tilemap, usamos o material na posição [0]
        if (tilemapRenderer.material.mainTexture == null)
        {
            Debug.LogError("O Tilemap Renderer não tem uma textura principal (mainTexture) atribuída.");
        }
    }

    void Update()
    {
        // 1. Calcula o offset (deslocamento) baseado no tempo e velocidade
        float offset = Time.time * velocidadeMovimento;

        // 2. Aplica o offset na coordenada X (horizontal) do material
        // Usamos o 'material' que está no index 0 (o primeiro material)
        tilemapRenderer.material.SetTextureOffset(MainTex, new Vector2(offset, 0));

        // ⚠️ ATENÇÃO: Se o seu Tilemap tem VÁRIOS materiais (para camadas diferentes), 
        // você precisará fazer um loop ou saber qual index usar.
    }
}
