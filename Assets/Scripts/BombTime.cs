using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class BombTime : MonoBehaviour {

	public GameObject bomb;
	
	private float _remainedTime;
	private float _maxRemaineTime = 100;
	private string _decreaseCountListener;
	private float _decreaseCount = 0.01f;

	void Start()
	{
		_remainedTime = _maxRemaineTime;
//decreaseCount = _decreaseCountListener가 보낸 값을 받음

	}
	
	void Update(){
		_remainedTime -= _decreaseCount;
			bomb.GetComponent<Image>().fillAmount = _remainedTime/_maxRemaineTime;

			if(bomb.GetComponent<Image>().fillAmount==0){
				SceneManager.LoadScene("GameOver_BombTimeOver");
			}

	}
	
}
