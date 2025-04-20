using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GradientTexture : MonoBehaviour
{
    void Start()
    {
        RawImage BackgroundImage = GetComponent<RawImage>();
        if (BackgroundImage == null)
        {
            Debug.LogError("RawImage component not found on " + gameObject.name);
            return;
        }

        Texture2D texture = new Texture2D(2, 2);
        texture.SetPixel(0, 0, new Color(0, 0.5f, 1)); // Blue for ocean
        texture.SetPixel(1, 0, new Color(0, 0.5f, 1));
        texture.SetPixel(0, 1, new Color(0.8f, 0.9f, 1)); // Light blue for sky
        texture.SetPixel(1, 1, new Color(0.8f, 0.9f, 1));
        texture.Apply();
        BackgroundImage.texture = texture; // Use texture instead of sprite for RawImage
    }
}
