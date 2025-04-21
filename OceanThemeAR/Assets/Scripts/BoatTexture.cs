using UnityEngine;

public class BoatTexture : MonoBehaviour
{
    void Start()
    {
        Texture2D texture = new Texture2D(128, 128);
        for (int x = 0; x < 128; x++)
        {
            for (int y = 0; y < 128; y++)
            {
                float noise = Mathf.PerlinNoise(x * 0.1f, y * 0.1f);
                Color color = new Color(0.4f + noise * 0.1f, 0.2f + noise * 0.05f, 0.1f);
                texture.SetPixel(x, y, color);
            }
        }
        texture.Apply();
        GetComponent<Renderer>().material.mainTexture = texture;
    }
}
