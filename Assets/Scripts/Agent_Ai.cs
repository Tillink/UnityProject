using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;

public class Agent_Ai : MonoBehaviour{

	public GameObject Agent;

	public int guardtime = 10;

	protected void Update () {
		guardtime -= 1;
		if(guardtime==0){
			
			Agent.isStatic=false;
		}
		
	}
}
