using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;          // Salud máxima del jugador
    public Slider healthBar;             // Barra de salud
    private int currentHealth;           // Salud actual del jugador

    void Start()
    {
        currentHealth = maxHealth;       // Inicializa la salud actual con la salud máxima
        UpdateHealthBar();               // Actualiza la barra de salud al inicio
    }

    public void TakeDamage(int damage)
    {
        Debug.Log($"Recibiendo daño: {damage}, Salud actual antes de daño: {currentHealth}");
        currentHealth -= damage;         // Reduce la salud actual
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth); // Asegura que la salud esté dentro del rango válido
        UpdateHealthBar();               // Actualiza la barra de salud
        Debug.Log($"Salud actual después de daño: {currentHealth}");
    }

    void UpdateHealthBar()
    {
        if (healthBar != null)
        {
            healthBar.maxValue = maxHealth;  // Configura el valor máximo del Slider
            healthBar.value = currentHealth; // Actualiza el valor del Slider a la salud actual
            Debug.Log($"Actualizando Slider: Valor del Slider: {healthBar.value}, Salud actual: {currentHealth}");
        }
        else
        {
            Debug.LogWarning("El campo 'healthBar' no está asignado en el script PlayerHealth.");
        }
        if (Input.GetKeyDown(KeyCode.T)) // Por ejemplo, presionar 'T' para probar
        {
            TakeDamage(10); // Aplica daño manualmente
        }
    }
}
