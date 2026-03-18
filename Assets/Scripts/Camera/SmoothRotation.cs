using UnityEngine;

public class SmoothRotation : MonoBehaviour
{
    [SerializeField] public float mouseSensitivity = 100f;
    public Transform playerBody;

    //Acumulative Rotatioon
    float xRotation = 0f; 
    float yRotation = 0f; 

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        // --- ROTACIÓN VERTICAL (CÁMARA) ---
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -10f, 45f); 
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        // --- ROTACIÓN HORIZONTAL (JUGADOR) ---
        yRotation += mouseX;
        yRotation = Mathf.Clamp(yRotation, -90f, 90f);
        playerBody.localRotation = Quaternion.Euler(0f, yRotation, 0f);
    }
}
