using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BossAreaAttack : MonoBehaviour
{
    public float attackRadius = 5f;        
    public float attackDamage = 20f;      
    public float attackInterval = 10f;     
    public float attackDuration = 3f;      // Duración del ataque en área en segundos (tiempo que el jefe se queda quieto)
    private float nextAreaAttackTime = 0f; 
    private Transform player;              
    private PlayerHealth playerHealth;     // Referencia al script de salud del jugador
    private NavMeshAgent agent;            // Referencia al NavMeshAgent del jefe

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        playerHealth = player.GetComponent<PlayerHealth>();
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        // Verifica si es tiempo de realizar el ataque en área
        if (Time.time >= nextAreaAttackTime)
        {
            StartCoroutine(PerformAreaAttack());
            nextAreaAttackTime = Time.time + attackInterval; // Configura el tiempo para el próximo ataque
        }
    }

    private IEnumerator PerformAreaAttack()
    {
        // Detiene al jefe durante el ataque en área
        if (agent != null)
        {
            agent.isStopped = true;
        }

        if (Vector3.Distance(transform.position, player.position) <= attackRadius)
        {
            playerHealth.TakeDamage(attackDamage);
            Debug.Log("Ataque en área realizado. Daño aplicado al jugador: " + attackDamage);
        }

        yield return new WaitForSeconds(attackDuration);

        if (agent != null)
        {
            agent.isStopped = false;
            agent.SetDestination(player.position); // Vuelve a seguir al jugador
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRadius);
    }
}
