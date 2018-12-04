using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileScale : MonoBehaviour {

	public float tileSize;
	Material tile;

	// Use this for initialization
	void Start () {
		tileSize = 5;
		tile = GetComponent<Renderer>().material;
		tile.mainTextureScale = new Vector2 (transform.localScale.x*tileSize,transform.localScale.z*tileSize);
	}
}
