using UnityEngine;

public class CameraCollider : MonoBehaviour
{
    public Transform target;          // El personaje
    public float maxDistance = 4f;    // Distancia normal de la cámara
    public float minDistance = 0.5f;  // Distancia mínima permitida
    public float smooth = 10f;        // Suavizado del movimiento
    public float radius = 0.2f;       // Radio para detectar colisiones

    private float currentDistance;

    void Start()
    {
        currentDistance = maxDistance;
    }

    void LateUpdate()
    {
        Vector3 direction = (transform.position - target.position).normalized;

        // Raycast para detectar paredes
        if (Physics.SphereCast(target.position, radius, direction, out RaycastHit hit, maxDistance))
        {
            currentDistance = Mathf.Clamp(hit.distance, minDistance, maxDistance);
        }
        else
        {
            currentDistance = maxDistance;
        }

        // Mover la cámara suavemente
        Vector3 desiredPosition = target.position + direction * currentDistance;
        transform.position = Vector3.Lerp(transform.position, desiredPosition, Time.deltaTime * smooth);
    }
}

