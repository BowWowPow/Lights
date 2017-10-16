using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleToSize : MonoBehaviour {

	private float collisionCount;
	private bool canScale;
	// Use this for initialization
	void Start () {
		canScale = true;
		collisionCount = 0;
	}

	void OnTriggerStay(Collider col){
		collisionCount = 1;
		transform.localScale += new Vector3(0.1f, 0.1f, 0);
	}

	void OnTriggerExit(Collider col){
		collisionCount = 0;
	}

	public bool GetCanScale(){
		return canScale;
	}

	public void SetCanScale(bool no){
		canScale = no;
	}

	void FixedUpdate(){
		if (collisionCount == 0 && canScale == true) {
			transform.localScale -= new Vector3(0.3f, 0.3f, 0);
       		Debug.Log ("No collision");
    	}
	}
}
