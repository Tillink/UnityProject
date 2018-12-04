using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;

public class GameOver_Caught : MonoBehaviourEx {

	
	void Caught(Collider collider){
		if(collider.CompareTag("Guard"))
		SceneManager.LoadScene("GameOver_CaughtByGuard");
	}
}
