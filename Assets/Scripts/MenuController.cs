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
	public void RestartGame(){
		SceneManager.LoadScene("Playing_game");
		
	}
	public void Btn_Start(){//메인메뉴-> 난이도 메뉴로
		SceneManager.LoadScene("Menu_start_difficulties");
	}

	public void Btn_GoOnGame(){//게임 본격 시작 20181109 기준 samplescene이 게임 시작임
		SceneManager.LoadScene("Playing_game");
	}

	public void Btn_EasyGameIntroScene(){//인트로 신 불러옴
		PlayerPrefs.SetFloat("_difficulty",0.01f);
		SceneManager.LoadScene("GameIntroScene");
	}

	public void Btn_NormalGameIntroScene(){//인트로 신 불러옴
		PlayerPrefs.SetFloat("_difficulty",0.03f);
		SceneManager.LoadScene("GameIntroScene");
	}
		public void Btn_HardGameIntroScene(){//인트로 신 불러옴
		PlayerPrefs.SetFloat("_difficulty",0.05f);
		SceneManager.LoadScene("GameIntroScene");
	}
	public void Btn_Score(){//점수메뉴
		SceneManager.LoadScene("Menu_score_chart");
	}
	public void Btn_Quit(){//종료
		Application.Quit();
	}
	public void Btn_Tomenu(){//어느신이든 이 버튼 누르면 메뉴로 돌아가기
		MouseUnlock();
		SceneManager.LoadScene("Menu_main");
	}
	public void Btn_escape(){//esc팝업메뉴
		if(Input.GetKeyDown(KeyCode.Escape))
			SceneManager.LoadScene("Menu_popup_whilePlaying");
	}
	private void MouseUnlock()
	{
		if(Cursor.lockState==CursorLockMode.Locked)
		{
			Cursor.lockState = CursorLockMode.None;
			Cursor.visible = true;
		}
	}
}
