using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonCamera : MonoBehaviour
{
    public float mouseSensitivity = 100f;  // Sensibilidad del mouse para la rotación de la cámara
    public Transform playerBody;           // Transform del jugador para seguir su rotación
    private float xRotation = 0f;          // Control de la rotación en el eje X (vertical)

    void Start()
    {
        // Bloquea el cursor en el centro de la pantalla y lo hace invisible
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        // Captura el movimiento del mouse
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        // Ajusta la rotación vertical del jugador (limitando el ángulo de visión para evitar giros completos)
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);  // Limita la rotación en el eje X

        // Aplica la rotación al Transform de la cámara
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        // Rota al jugador en el eje Y (horizontal) para girar con el mouse
        if (playerBody != null)
        {
            playerBody.Rotate(Vector3.up * mouseX);
        }
    }
}
