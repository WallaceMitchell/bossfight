using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMeleeAttack : MonoBehaviour
{
    public int attackDamage = 10;         // Daño que el jefe inflige al jugador
    public float attackCooldown = 1f;     // Tiempo de enfriamiento entre ataques
    private float nextAttackTime = 0f;    // Tiempo hasta que el jefe puede atacar nuevamente

    void OnCollisionEnter(Collision collision)
    {
            Debug.Log("Colisión detectada con: " + collision.gameObject.name); // Verificar la colisión
        Debug.Log($"Etiqueta del objeto colisionado: {collision.gameObject.tag}"); // Mostrar la etiqueta

        // Depuración para el tiempo y el valor de cooldown
        Debug.Log($"Tiempo actual: {Time.time}, Próximo ataque permitido a partir de: {nextAttackTime}");

        // Verifica la condición completa
        if (collision.gameObject.CompareTag("Player") && Time.time >= nextAttackTime)
        {
        PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
        if (playerHealth != null)
        {
            Debug.Log("Aplicando daño al jugador."); // Depuración para verificar la llamada a TakeDamage
            playerHealth.TakeDamage(attackDamage);  // Aplica daño al jugador
            nextAttackTime = Time.time + attackCooldown;  // Actualiza el tiempo del próximo ataque
            Debug.Log($"Próximo ataque posible en: {nextAttackTime} segundos.");
        }
        else
        {
            Debug.LogWarning("PlayerHealth no encontrado en el jugador."); // Depuración si el componente no se encuentra
        }
        }
         else
        {
        // Depuración para saber exactamente qué condición falla
        if (!collision.gameObject.CompareTag("Player"))
        {
            Debug.LogWarning("La etiqueta del objeto colisionado no es 'Player'.");
        }
        if (Time.time < nextAttackTime)
        {
            Debug.LogWarning("El ataque aún está en cooldown. Esperando a que pase el tiempo de cooldown.");
        }
        }
        }
}
