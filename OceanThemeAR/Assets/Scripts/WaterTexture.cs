using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterTexture : MonoBehaviour
{
    void Start()
    {
        Texture2D texture = new Texture2D(256, 256);
        for (int x = 0; x < 256; x++)
        {
            for (int y = 0; y < 256; y++)
            {
                float noise = Mathf.PerlinNoise(x * 0.1f, y * 0.1f);
                Color color = new Color(0, 0.2f + noise * 0.1f, 0.5f + noise * 0.1f);
                texture.SetPixel(x, y, color);
            }
        }
        texture.Apply();
        GetComponent<Renderer>().material.mainTexture = texture;
    }
}
