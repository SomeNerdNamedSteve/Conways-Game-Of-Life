using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	//the cell will become alive or dead based on the cells around it.
	public GameObject cell;

	//Even though the scale of the UI Object is 3.75, that
	//is 50% of a unit of length in Unity
	private const float SIZE = 0.5f;
	private const float X_LIMIT=8.6f;
	private const float Y_LIMIT=4.7f;
	

	// Use this for initialization
	void Start () {
		for(float x = -X_LIMIT; x <= X_LIMIT; x += 0.5f){
			for(float y = -Y_LIMIT; y <= Y_LIMIT; y += 0.5f){
				Instantiate(cell, new Vector2(x,y), Quaternion.identity);
			}
		}
	}
}
