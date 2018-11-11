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
		Escaped();
	}
	
	public void FallingDown(){
		
		if(Playerobj.transform.position.y<-20){
			Debug.Log("자폭");
			SceneManager.LoadScene("GameOver_Fallen");
		}


	}
	public void Escaped(){
		if(Playerobj.transform.position.z<-90){
			Debug.Log("성공적으로 탈출");
			SceneManager.LoadScene("Menu_main");
		}
	}

}
