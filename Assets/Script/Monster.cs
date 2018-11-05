using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class Monster : MonoBehaviour
{

    public Transform target;
    Vector3 destination;
    NavMeshAgent agent;



    // Use this for initialization
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        destination = agent.destination;
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {


            if (Vector3.Distance(destination, target.position) > 1.0f)
            {
                destination = target.position;
                agent.destination = destination;
            }
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            target = other.gameObject.transform;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            target = null;
            agent.destination = transform.position;
        }
    }

}

