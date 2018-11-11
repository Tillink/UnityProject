using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviourEx {
public GameObject Pausemenu;

public GameObject Playerobj;

	protected override void Update () {
		
		if(Input.GetKeyDown(KeyCode.Escape)){
			if(Pausemenu.gameObject.activeInHierarchy==false){
				Pausemenu.gameObject.SetActive(true);
			}
			else if(Pausemenu.gameObject.activeInHierarchy==true)
				Pausemenu.gameObject.SetActive(false);
			
		}
		FallingDown();
	}
	
	public void FallingDown(){
		
		if(Playerobj.transform.position.y<-20){
			SceneManager.LoadScene("GameOver_Fallen");
		}


	}

}
