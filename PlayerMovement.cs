using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;  // Velocidad de movimiento del jugador
    private Rigidbody rb;         // Referencia al componente Rigidbody del jugador
    private Vector3 moveDirection; // Dirección de movimiento calculada

    void Start()
    {
        // Obtiene el componente Rigidbody del objeto
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Captura la entrada del teclado para movimiento
        float moveX = Input.GetAxis("Horizontal"); // Movimiento lateral (A y D)
        float moveZ = Input.GetAxis("Vertical");   // Movimiento hacia adelante y atrás (W y S)

        // Calcula la dirección de movimiento
        moveDirection = new Vector3(moveX, 0, moveZ).normalized;
    }

    void FixedUpdate()
    {
        // Aplica el movimiento al Rigidbody
        rb.MovePosition(rb.position + moveDirection * moveSpeed * Time.fixedDeltaTime);
    }
}
