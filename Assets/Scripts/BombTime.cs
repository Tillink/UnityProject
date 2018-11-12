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
	private float _decreaseCount;
private string _difficulty;
	void Start()
	{
		_decreaseCount = PlayerPrefs.GetFloat(_difficulty);
		PlayerPrefs.DeleteKey(_difficulty);
		Debug.Log(_decreaseCount);
		_remainedTime = _maxRemaineTime;
//decreaseCount = _difficulty가 보낸 값을 받음

	}
	
	void Update(){
		_remainedTime -= _decreaseCount;
			bomb.GetComponent<Image>().fillAmount = _remainedTime/_maxRemaineTime;

			if(bomb.GetComponent<Image>().fillAmount==0){
				SceneManager.LoadScene("GameOver_BombTimeOver");
			}

	}
	
}
