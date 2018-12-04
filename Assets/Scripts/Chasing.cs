using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Chasing : MonoBehaviour {

    public Transform target;//대상이 바뀌는 경우엔 반드시 null 표기가 필요
    internal Vector3 destination;
    internal NavMeshAgent agent;
	// Update is called once per frame
	void Update () 
	{
        destination = target.position;
        agent.destination = destination;
	}
}
