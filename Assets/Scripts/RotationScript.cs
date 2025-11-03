using UnityEngine;

public class RotationAndScaleScript : MonoBehaviour
{
    [Header("Rotation Settings")]
    [SerializeField] private float maxAngle = 5f;  // Maximum rotation angle
    [SerializeField] private float rotationSpeed = 1f;  // Speed of rotation sway

    [Header("Scale Settings")]
    [SerializeField] private float minScale = 0.4f;  // Minimum scale
    [SerializeField] private float maxScale = 0.6f;  // Maximum scale
    [SerializeField] private float scaleSpeed = 1f;   // Speed of scale pulsing

    private float startZ;

    void Start()
    {
        startZ = transform.eulerAngles.z;
    }

    void Update()
    {
        // --- Rotation ---
        float zRotation = startZ + Mathf.Sin(Time.time * rotationSpeed) * maxAngle;
        transform.rotation = Quaternion.Euler(0f, 0f, zRotation);

        // --- Scale ---
        float scaleFactor = Mathf.Lerp(minScale, maxScale, (Mathf.Sin(Time.time * scaleSpeed) + 1f) / 2f);
        transform.localScale = new Vector3(scaleFactor, scaleFactor, 1f);
    }
}
