using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Chasing : PatrolAI {
	void Update () 
	{
        destination = target.position;
        agent.destination = destination;
	}
}
