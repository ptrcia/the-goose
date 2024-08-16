using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Rendering;

public class FollowLeader : MonoBehaviour
{
    public Transform leader; // El primer pato que el segundo debe seguir
    public float followDistance = 2f; // Distancia a la que el segundo pato debe seguir al primero
    public float angularSpeed= 120f;
    public float acceleration = 8f;
    public float speed = 3.5f;

    private NavMeshAgent navMeshAgent;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();

        if (leader == null)
        {
            Debug.LogError("Leader is not assigned.");
            return;
        }

        if (navMeshAgent == null)
        {
            Debug.LogError("No NavMeshAgent component found on this GameObject.");
            return;
        }

        // Ajusta el NavMeshAgent para que se mueva de manera más natural
        navMeshAgent.autoBraking = true; // Para frenar de forma suave
        navMeshAgent.angularSpeed = angularSpeed; // Velocidad de giro
        navMeshAgent.acceleration = acceleration; // Aceleración
        navMeshAgent.speed = speed; // Velocidad de movimiento
    }

    void Update()
    {
        if (leader != null && navMeshAgent != null)
        {
            // Calcular la posición deseada del segundo pato
            Vector3 followPosition = leader.position - leader.forward * followDistance;

            // Actualizar el destino del NavMeshAgent del segundo pato
            navMeshAgent.SetDestination(followPosition);
        }
    }
}