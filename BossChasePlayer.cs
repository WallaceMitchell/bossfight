using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;  // Necesario para usar NavMeshAgent

public class BossChasePlayer : MonoBehaviour
{
    private NavMeshAgent agent;       // Referencia al NavMeshAgent del jefe
    private Transform player;         // Referencia al transform del jugador
    public float chaseRange = 20f;    // Distancia dentro de la cual el jefe empieza a perseguir al jugador

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();  // Obtener el componente NavMeshAgent del jefe
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        // Solo persigue al jugador si el agente no está detenido
        if (agent != null && !agent.isStopped)
        {
            float distanceToPlayer = Vector3.Distance(player.position, transform.position);
            if (distanceToPlayer <= chaseRange)
            {
                agent.SetDestination(player.position);  // Configura el destino del agente a la posición del jugador
            }
            else
            {
                agent.SetDestination(transform.position); // Detén al jefe si el jugador está fuera de rango
            }
        }
    }
}
