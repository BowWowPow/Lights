using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToMovementMask : MonoBehaviour {
	public float speed;
	private GameObject targetObj;
	private Transform targetTransform;
	private bool canMove;
	// Use this for initialization
	void Start () {
		canMove = true;
		speed = 2.0f;
	}

	void FixedUpdate(){
		if(targetObj == null){
			Debug.Log("Cannot Find Mask");
			targetObj = GameObject.FindGameObjectWithTag("MovementMask");
			targetTransform = targetObj.transform;
		}
		if(canMove){
			float step = speed * Time.deltaTime;
 			transform.position = Vector3.Lerp(new Vector3(transform.position.x,transform.position.y,-10.0f), targetTransform.position, step);
		}
	}

	public void SetCanMove(bool b){
		canMove = b;
	}
}
