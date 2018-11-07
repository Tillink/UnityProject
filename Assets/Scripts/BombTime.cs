using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;

public class BombTime : MonoBehaviour {

	public GameObject bomb;
	
	public float _decreaseCount = 0.01f;
	public void Update(){
			bomb.GetComponent<Image>().fillAmount -= _decreaseCount;

	}
}
