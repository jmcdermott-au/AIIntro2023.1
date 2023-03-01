using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;



//in case there's no navmesh agent, otherwise it would make agent.destination nothing.
[RequireComponent(typeof(NavMeshAgent))]
public class MoveToObject : MonoBehaviour
{
	
	public Transform target;
	private NavMeshAgent _agent;
	
	
	
    // Start is called before the first frame update
    void Start()
    { //finds the component attatched to the le thing
       _agent = GetComponent<NavMeshAgent>();   
    }

    // Update is called once per frame
    void Update()
    {
      _agent.destination = target.position;  
    }
}
