using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileScale : MonoBehaviour {

	public float tileSize;

	// Use this for initialization
	void Start () {
		GetComponent<Material>().mainTextureScale = new Vector2(transform.localScale.x*tileSize,transform.localScale.z*tileSize);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
