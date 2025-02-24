using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    public float zoomSpeed = 50f;
    public float minZoom = 10f;
    public float maxZoom = 500f;
    public float transitionSpeed = 3f;

    private Camera cam;
    private float currentZoom;

    void Start()
    {
        cam = Camera.main;
        currentZoom = cam.fieldOfView;
    }

    void Update()
    {
        HandleZoom();
        HandleMovement();
    }

    void HandleZoom()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        if (scroll != 0f)
        {
            currentZoom -= scroll * zoomSpeed;
            currentZoom = Mathf.Clamp(currentZoom, minZoom, maxZoom);
            cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, currentZoom, Time.deltaTime * transitionSpeed);
        }
    }

    void HandleMovement()
    {
        if (Input.GetMouseButton(1))
        {
            float h = Input.GetAxis("Mouse X") * 10f;
            float v = Input.GetAxis("Mouse Y") * 10f;
            transform.Translate(-h, -v, 0);
        }
    }
}
