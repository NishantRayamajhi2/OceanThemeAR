using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScaleAnimation : MonoBehaviour
{
    private Vector3 originalScale;
    private float animationTime = 1f; // Total animation duration (1 second)
    private float scaleAmount = 1.1f; // Scale up to 1.1
    private float timer = 0f;

    void Start()
    {
        originalScale = transform.localScale; // Store the original scale
    }

    void Update()
    {
        timer += Time.deltaTime;
        float t = (Mathf.Sin(timer * Mathf.PI * 2 / animationTime) + 1) / 2; // Oscillate between 0 and 1
        float currentScale = Mathf.Lerp(originalScale.x, originalScale.x * scaleAmount, t);
        transform.localScale = new Vector3(currentScale, currentScale, currentScale);
    }
}
