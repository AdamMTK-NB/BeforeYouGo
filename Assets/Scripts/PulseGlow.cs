using UnityEngine;

public class PulseGlow : MonoBehaviour
{
    public float pulseSpeed = 2f;
    public float minScale = 0.04f;
    public float maxScale = 0.07f;

    void Update()
    {
        float scale = Mathf.Lerp(minScale, maxScale,
            (Mathf.Sin(Time.time * pulseSpeed) + 1) / 2);
        transform.localScale = Vector3.one * scale;
    }
}