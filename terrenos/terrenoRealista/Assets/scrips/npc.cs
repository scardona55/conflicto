using UnityEngine;
using UnityEngine.AI;

public class npc : MonoBehaviour
{
    public Transform target;
    NavMeshAgent agent;
    Vector3 startPoint; // Variable para almacenar el punto de partida

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        startPoint = transform.position; // Establecer el punto de partida como la posición inicial del NPC
    }

    void Start()
    {
        agent.SetDestination(target.position);
    }

    void Update()
    {
        // Si el agente ha llegado a su destino
        if (!agent.pathPending && agent.remainingDistance <= agent.stoppingDistance)
        {
            // Configura el nuevo destino al punto de origen
            agent.SetDestination(startPoint);
        }
    }
}
