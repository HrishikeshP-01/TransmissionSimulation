using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Locomotion : MonoBehaviour
{
    NavMeshAgent agent;
    [SerializeField]
    private Transform destination;
    
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.SetDestination(destination.position);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Person")
        {
            // Transfer infection
            Debug.Log("Infection spreads");
        }
        Debug.Log("Overlap");
    }
}
