using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.UI;



public class MenuController : MonoBehaviour
{
	

//----------------------------------------

	public void Btn_Start(){//메인메뉴-> 난이도 메뉴로
		Debug.Log("1");
		SceneManager.LoadScene("Menu_start_difficulties");
	}

	public void Btn_GoOnGame(){//게임 본격 시작 20181109 기준 samplescene이 게임 시작임
		Debug.Log("GoOn");
		SceneManager.LoadScene("SampleScene");
	}

	public void Btn_GameIntroScene(){//인트로 신 불러옴
		Debug.Log("gmaeintro");
		SceneManager.LoadScene("GameIntroScene");
	}

	public void Btn_Score(){//점수메뉴
		Debug.Log("2");
		SceneManager.LoadScene("Menu_score_chart");
	}
	public void Btn_Quit(){//종료
		Debug.Log("3");
		Application.Quit();
	}
	public void Btn_Tomenu(){//어느신이든 이 버튼 누르면 메뉴로 돌아가기
		Debug.Log("4");
		SceneManager.LoadScene("Menu_main");
	}
	public void Btn_escape(){//esc팝업메뉴
		Debug.Log("5");
		if(Input.GetKeyDown(KeyCode.Escape))
			SceneManager.LoadScene("Menu_popup_whilePlaying");
	}
}
