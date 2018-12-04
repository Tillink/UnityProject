using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class PatrolAI : MonoBehaviour
{
//이 AI는 Waypoint와 Chase를 운용하는 스크립트임.

    private RaycastHit _raycastHit;
    private Chasing chasing;
    private Waypoint waypoint;
    private Vector3 destination;
    private NavMeshAgent agent;
    void OnEnable()
    {
        agent = GetComponent<NavMeshAgent>();
        destination = agent.destination;
        chasing = GetComponent<Chasing>();
        waypoint = GetComponent<Waypoint>();

        chasing.agent = agent;
        chasing.destination = agent.destination;
        waypoint.agent = agent;
        waypoint.destination = agent.destination;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
            {
                Vector3 dir = other.transform.position - transform.position;
               Physics.Raycast(
                    transform.position,
                    dir.normalized,
                    out _raycastHit,
                    Mathf.Infinity);
                    
               if(_raycastHit.collider.tag == "Player")
                {
                waypoint.enabled = false;
                chasing.enabled = true;
                GetComponent<NavMeshAgent>().speed = 5;
                GetComponent<SphereCollider>().radius = 7.5f;
                 GetComponent<SphereCollider>().center = new Vector3(0,1.55f,9.9f);

                chasing.target = other.transform;
                
                if(waypoint.isCameback)
                {
                waypoint.returnPoint = transform;
                waypoint.isCameback = false;
                waypoint.nCurTarget--;
                }
                }            
            }
        }
    

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            chasing.enabled = false;
            waypoint.enabled = true;
            GetComponent<NavMeshAgent>().speed = 3.5f;
            GetComponent<SphereCollider>().radius = 4.5f;
            GetComponent<SphereCollider>().center = new Vector3(0,1.55f,6.2f);
        }
    }
}