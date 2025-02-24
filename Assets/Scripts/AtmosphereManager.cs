using UnityEngine;

public class AtmosphereManager : MonoBehaviour
{
    public GameObject atmosphereEffect;
    public float fadeSpeed = 2f;

    private Camera cam;
    private float targetAlpha = 0f;

    void Start()
    {
        cam = Camera.main;
        UpdateAtmosphere();
    }

    void Update()
    {
        UpdateAtmosphere();
    }

    void UpdateAtmosphere()
    {
        float zoom = cam.fieldOfView;
        targetAlpha = Mathf.Clamp01(1 - (zoom / 100f));

        Color color = atmosphereEffect.GetComponent<Renderer>().material.color;
        color.a = Mathf.Lerp(color.a, targetAlpha, Time.deltaTime * fadeSpeed);
        atmosphereEffect.GetComponent<Renderer>().material.color = color;
    }
}
