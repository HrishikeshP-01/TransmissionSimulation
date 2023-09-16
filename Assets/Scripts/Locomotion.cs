using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Locomotion : MonoBehaviour
{
    NavMeshAgent agent;
    [SerializeField]
    private Transform[] totalDestinationPts;
    private Transform[] destinations;
    [SerializeField]
    bool isHost;
    [SerializeField]
    bool carriesInfection;
    [SerializeField]
    Material InfectedMat;
    [SerializeField]
    Material SickMat;

    Vector3 targetPt;
    int targetIndex = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        destinations = new Transform[totalDestinationPts.Length];
        getRandomDPs();
        isHost = Randomizer();
        if (carriesInfection)
        {
            if (isHost) { GetComponent<MeshRenderer>().material = InfectedMat; }
            else { GetComponent<MeshRenderer>().material = SickMat; }
        }
        agent = GetComponent<NavMeshAgent>();
        agent.SetDestination(destinations[targetIndex].position);
    }

    // Update is called once per frame
    void Update()
    {
       if(Vector3.Distance(transform.position, targetPt) < 1.0f)
        {
            targetPt = destinations[(targetIndex + 1) % destinations.Length].position;
            agent.SetDestination(targetPt);
        } 
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag != "Person") { Debug.Log("X"); return; }
        if (other.gameObject.GetComponent<Locomotion>().carriesInfection)
        {
            // Transfer infection
            Debug.Log("Infection spreads");
            carriesInfection = true;
            getInfected();
            getSick();
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

    void getSick()
    {
        if(!isHost)
        {
            gameObject.GetComponent<MeshRenderer>().material = SickMat;
        }
    }

    void getRandomDPs()
    {
        for(int i=0;i<totalDestinationPts.Length;i++)
        {
            destinations[i] = totalDestinationPts[Mathf.RoundToInt(Random.Range(0, totalDestinationPts.Length))];
        }
    }

    bool Randomizer()
    {
        if (Random.Range(1, 10) < 2) { return true; }
        return false;
    }
}
