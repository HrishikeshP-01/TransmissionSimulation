using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Locomotion : MonoBehaviour
{
    NavMeshAgent agent;
    [SerializeField]
    private Transform destination;
    [SerializeField]
    bool isHost;
    [SerializeField]
    Material InfectedMat;
    
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
            // Debug.Log("Infection spreads");
            getInfected();
        }
        //Debug.Log("Overlap");
    }

    void getInfected()
    {
        if(isHost)
        {
            gameObject.GetComponent<MeshRenderer>().material = InfectedMat;
        }
    }
}
