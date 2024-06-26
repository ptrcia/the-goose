using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Patrol : MonoBehaviour
{
    public float speed = 5f; // Velocidad de movimiento del objeto
    public float changeDestinationInterval = 5f; // Intervalo para cambiar de destino
    public float rotationSpeed = 5f; // Velocidad de rotación

    private NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.speed = Random.Range(1, 7);
        StartCoroutine(ChangeDestination());
    }

    void Update()
    {
        if (agent.remainingDistance < 0.1f && !agent.pathPending)
        {
            agent.SetDestination(GetRandomPointInNavMesh());
        }
        LookAtTarget();
    }

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

        Quaternion newRotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * rotationSpeed);

        transform.rotation = newRotation;
    }
}