using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Class to help manage the state of each cell
public class CellManager : MonoBehaviour {

	private SpriteRenderer r;
	public float val;

	private float nextTime = 1;
	private float interval = 0.5f;

	// Use this for initialization
	void Start () {
		r = GetComponent<SpriteRenderer>();
		val = Random.value;
		r.color = (val >= 0.5f) ? Color.white : Color.black;
	}

	// Update is called once per frame
	void Update () {

		if(Time.time >= nextTime){
			int numNeighbors = GetNumNeighbors();
			if(r.color == Color.white){
				if(numNeighbors > 3 || numNeighbors < 2){ r.color = Color.black; }
			}else{
				if(numNeighbors == 3){ r.color = Color.white; }
			}

			nextTime += interval;

		}
	}


	//Gives the number of neighbors used by each cell.  
	private int GetNumNeighbors(){

		int alive = 0;

		Vector3 up = 0.5f * transform.up;
		Vector3 down = 0.5f * -transform.up;
		Vector3 left = 0.5f * -transform.right;
		Vector3 right = 0.5f * transform.right;
		Vector3 upLeft = up + left;
		Vector3 upRight = up + right;
		Vector3 downLeft = down + left;
		Vector3 downRight = down + right;

		Vector3[] positions = {upLeft, up, upRight, left, right, downLeft, down, downRight};

		RaycastHit hit;
		foreach(Vector3 pos in positions){
			if(Physics.Raycast(transform.position, pos, out hit)){
				GameObject neighborCell = hit.collider.gameObject;
				SpriteRenderer neighborRender = neighborCell.GetComponent<SpriteRenderer>();
				if(neighborRender.color == Color.white){ alive++; }
			}
		}
		return alive;
	}
}
