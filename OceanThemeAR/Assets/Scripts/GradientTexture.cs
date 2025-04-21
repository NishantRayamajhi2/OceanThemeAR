using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GradientTexture : MonoBehaviour
{
    void Start()
    {
        Image BackgroundImage = GetComponent<Image>();
        if (BackgroundImage == null)
        {
            Debug.LogError("Image component not found on " + gameObject.name);
            return;
        }

        Texture2D texture = new Texture2D(2, 2);
        texture.SetPixel(0, 0, new Color(0, 0.5f, 1));
        texture.SetPixel(1, 0, new Color(0, 0.5f, 1));
        texture.SetPixel(0, 1, new Color(0.8f, 0.9f, 1));
        texture.SetPixel(1, 1, new Color(0.8f, 0.9f, 1));
        texture.Apply();
        Sprite sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));
        BackgroundImage.sprite = sprite;
    }
}
