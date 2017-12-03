using UnityEngine;

public class CamFollow : MonoBehaviour
{

    [Header("Camera Attributes")]
    public float cameraSpeed = 0.01f;
    [Header("Camera Bounds")]
    public float xMin;
    public float xMax;
    public float yMin;
    public float yMax;
    [Header("Required References")]
    public Transform target;
    Camera cam;

    // Use this for initialization
    void Start()
    {
        cam = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {

        if (target == null)
            return;

        transform.position = Vector3.Lerp(transform.position, new Vector3(target.position.x, target.position.y, -10), cameraSpeed);
    }
}
