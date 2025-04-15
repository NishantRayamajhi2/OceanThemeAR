using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class BuoyBob : MonoBehaviour
{
    public float bobSpeed = 1f;
    public float bobHeight = 0.5f;
    private Vector3 startPos;
    void Start()
    {
        startPos = transform.position;
    }
    void Update()
    {
        float newY = startPos.y + Mathf.Sin(Time.time * bobSpeed) * bobHeight;
        transform.position = new Vector3(startPos.x, newY, startPos.z);
    }
}
