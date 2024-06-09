using UnityEngine;
using UnityEngine.AI;

public class ainavegacionNPC : MonoBehaviour
{
    NavMeshAgent agent;
    public Transform target;

    private void Awake(){
        agent = GetComponent<NavMeshAgent>();
    }

    private void Start(){}
}
