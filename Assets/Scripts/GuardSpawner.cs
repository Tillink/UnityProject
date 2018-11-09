using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardSpawner : MonoBehaviour {
	private float _guardSpawnTimer;
	private bool _isGuardSpawn = false;

	public GameObject guard;
	// Use this for initialization
	void Start () {
		_guardSpawnTimer = 10;
	}
	
	// Update is called once per frame
	void Update () {
		if(!_isGuardSpawn)
		{
			_guardSpawnTimer -= Time.deltaTime;
		if(_guardSpawnTimer == 0)
		{
			_guardSpawnTimer = 10;
			Instantiate(guard,transform.position,transform.rotation);
		}
		}
	}
}
