using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;  // Componente CharacterController del jugador
    public Transform playerBody;            // Transform del cuerpo del jugador (sin incluir la cámara)
    public Camera playerCamera;             // Cámara del jugador
    public float speed = 5f;                // Velocidad de movimiento
    public float mouseSensitivity = 100f;   // Sensibilidad del ratón
    private float xRotation = 0f;           // Rotación acumulada en el eje X (vertical)

    void Start()
    {
        // Bloquea el cursor al centro de la pantalla y lo hace invisible
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        // Movimiento de la cámara con el ratón
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        // Ajusta la rotación vertical de la cámara, con clamping para evitar vueltas completas
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);  // Limita la rotación vertical para evitar voltearse completamente

        // Aplica la rotación acumulada al eje X de la cámara (vertical)
        playerCamera.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        // Rota el cuerpo del jugador horizontalmente con el ratón
        playerBody.Rotate(Vector3.up * mouseX);

        // Movimiento del jugador con WASD en la dirección en la que mira la cámara
        float horizontal = Input.GetAxis("Horizontal");  // Movimiento en eje X (A/D)
        float vertical = Input.GetAxis("Vertical");      // Movimiento en eje Z (W/S)

        // Calcula la dirección de movimiento en función de la orientación del jugador
        Vector3 move = playerBody.forward * vertical + playerBody.right * horizontal;

        // Mueve el CharacterController en la dirección calculada
        controller.Move(move * speed * Time.deltaTime);
    }
}
