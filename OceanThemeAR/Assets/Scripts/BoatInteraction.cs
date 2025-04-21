using UnityEngine;

public class BoatInteraction : MonoBehaviour
{
    private bool isLarge = false;
    private float lastClickTime = 0;
    private float doubleClickTime = 0.3f;
    private AudioSource audioSource;
    private GameObject glowEffect;
    private bool isSailing = false;
    private float sailTimer = 0f;
    private float sailDuration = 2f;
    private Vector3 originalPosition;
    private float sailDistance = 2f;
    private float bobTimer = 0f;
    private float bobSpeed = 1f;
    private float bobHeight = 0.05f;

    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        AudioClip audioClip = AudioClip.Create("WaveSound", 44100, 1, 44100, false);
        if (audioClip == null)
        {
            Debug.LogError("Failed to create WaveSound AudioClip in BoatInteraction.cs");
            return;
        }
        float[] samples = new float[44100];
        for (int i = 0; i < samples.Length; i++)
        {
            samples[i] = Mathf.Sin(i * 0.1f) * 0.5f;
        }
        audioClip.SetData(samples, 0);
        audioSource.clip = audioClip;
        audioSource.volume = 0.6f;
        audioSource.loop = false;

        glowEffect = GameObject.CreatePrimitive(PrimitiveType.Cube);
        glowEffect.transform.SetParent(transform);
        glowEffect.transform.localPosition = Vector3.zero;
        glowEffect.transform.localScale = new Vector3(2.6f, 0.6f, 1.1f);
        Material glowMat = new Material(Shader.Find("Unlit/Color"));
        glowMat.color = new Color(0, 1, 1);
        glowEffect.GetComponent<Renderer>().material = glowMat;

        originalPosition = transform.position;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit) && hit.transform == transform)
            {
                float currentTime = Time.time;
                if (currentTime - lastClickTime < doubleClickTime)
                {
                    isSailing = true;
                    sailTimer = 0f;
                    if (audioSource.clip != null)
                    {
                        audioSource.Play();
                    }
                    else
                    {
                        Debug.LogWarning("AudioSource clip is null in BoatInteraction.cs");
                    }
                }
                lastClickTime = currentTime;
                isLarge = !isLarge;
                transform.localScale = isLarge ? transform.localScale * 2 : transform.localScale / 2;
            }
        }
        if (Input.GetMouseButton(0))
        {
            float rotateSpeed = 50f;
            float mouseX = Input.GetAxis("Mouse X");
            transform.Rotate(0, -mouseX * rotateSpeed * Time.deltaTime, 0);
        }

        if (isSailing)
        {
            sailTimer += Time.deltaTime;
            float t = sailTimer / sailDuration;
            if (t >= 1f)
            {
                isSailing = false;
                transform.position = new Vector3(originalPosition.x, transform.position.y, originalPosition.z);
            }
            else
            {
                float progress = t < 0.5f ? t / 0.5f : (1f - t) / 0.5f;
                float zOffset = Mathf.Lerp(0f, sailDistance, progress);
                transform.position = new Vector3(originalPosition.x, transform.position.y, originalPosition.z) + transform.forward * zOffset;
            }
        }

        bobTimer += Time.deltaTime;
        float bobOffset = Mathf.Sin(bobTimer * bobSpeed) * bobHeight;
        float bobRotation = Mathf.Cos(bobTimer * bobSpeed) * 2f;
        transform.position = new Vector3(transform.position.x, originalPosition.y + bobOffset, transform.position.z);
        transform.rotation = Quaternion.Euler(bobRotation, transform.eulerAngles.y, 0);
    }
}
