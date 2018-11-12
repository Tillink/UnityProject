using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviourEx {
public GameObject Pausemenu;

public GameObject Playerobj;

[AutoLoad]
public GameObject btn_restart;
[AutoLoad]
public GameObject btn_tomenu;
[AutoLoad]
public GameObject btn_quit;
	protected override void Update () {
		
		if(Input.GetKeyDown(KeyCode.Escape)){
			
			if(Pausemenu.gameObject.activeInHierarchy==false){
				Pausemenu.gameObject.SetActive(true);
				OnApplicationPause(true);
				
				if(Input.GetMouseButtonDown(0)){
					if(btn_restart)
					SceneManager.LoadScene("Playing_game");

					if(btn_tomenu)
					SceneManager.LoadScene("Menu_main");

					if(btn_quit)
					Application.Quit();
				}
				
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
