using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Patrol : MonoBehaviour
{
    public float speed = 5f; // Velocidad de movimiento del objeto
    public float changeDestinationInterval = 5f; // Intervalo para cambiar de destino
    public float rotationSpeed = 5f; // Velocidad de rotaci�n

    private NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.speed = Random.Range(1, 7);
        // Comenzar la rutina para cambiar de destino peri�dicamente
        StartCoroutine(ChangeDestination());
    }

    void Update()
    {
        if (agent.remainingDistance < 0.1f && !agent.pathPending)
        {
            // Si el agente ha llegado a su destino actual y no est� calculando una nueva ruta
            agent.SetDestination(GetRandomPointInNavMesh());
        }
        LookAtTarget();
    }

    // M�todo para obtener un punto aleatorio dentro del NavMesh
    Vector3 GetRandomPointInNavMesh()
    {
        NavMeshHit hit;
        Vector3 randomPosition = Vector3.zero;
        if (NavMesh.SamplePosition(Random.insideUnitSphere * agent.radius * 20 + transform.position, out hit, agent.radius * 20, NavMesh.AllAreas))
        {
            randomPosition = hit.position;
        }
        return randomPosition;
    }

    // Rutina para cambiar de destino peri�dicamente
    IEnumerator ChangeDestination()
    {
        while (true)
        {
            yield return new WaitForSeconds(changeDestinationInterval);
            agent.SetDestination(GetRandomPointInNavMesh());
        }
    }

    void LookAtTarget()
    {
        Vector3 direction = (agent.steeringTarget - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(direction);

        // Calcula la rotaci�n suavizada
        Quaternion newRotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * rotationSpeed);

        // Aplica la rotaci�n al objeto
        transform.rotation = newRotation;
    }
}