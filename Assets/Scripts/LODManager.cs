using UnityEngine;

public class LODManager : MonoBehaviour
{
    public GameObject galaxyView;
    public GameObject systemView;
    public GameObject planetView;

    public float systemZoomThreshold = 300f;
    public float planetZoomThreshold = 50f;

    private Camera cam;

    void Start()
    {
        cam = Camera.main;
        UpdateLOD();
    }

    void Update()
    {
        UpdateLOD();
    }

    void UpdateLOD()
    {
        float zoom = cam.fieldOfView;

        galaxyView.SetActive(zoom > systemZoomThreshold);
        systemView.SetActive(zoom <= systemZoomThreshold && zoom > planetZoomThreshold);
        planetView.SetActive(zoom <= planetZoomThreshold);
    }
}
