using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscLever : MonoBehaviour {
public bool trapDoorOpen = false;

	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.tag == "Player"&&trapDoorOpen == false)
		{
			transform.Translate(0,-1,0);
			trapDoorOpen = true;
		}
	}
}
