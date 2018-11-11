using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingBookShelf : MonoBehaviour {

public GameObject lever;
private bool doorOpen = false;
	// Update is called once per frame
	void Update () 
	{
		if(lever.GetComponent<EscLever>().trapDoorOpen&&doorOpen ==false)
		{
			transform.Rotate(new Vector3(0,42.5f,0));
			doorOpen = true;
		}
	}
}
