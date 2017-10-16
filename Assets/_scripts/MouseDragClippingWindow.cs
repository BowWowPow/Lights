using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseDragClippingWindow : MonoBehaviour {

	public float distance;
	private int collisions;
	public GameObject ClippingMaskPrefab;
	private Vector3 screenPoint;
	private Vector3 offset;
	void Start(){
		collisions = 0;
		distance = -11;
	}

	void Update(){
		if(ClippingMaskPrefab == null){
			Debug.Log("Cannot Find Mask");
			ClippingMaskPrefab = GameObject.FindGameObjectWithTag("ClippingMask");
		}

		if(collisions == 0){
			ClippingMaskPrefab.GetComponent<ScaleToSize>().SetCanScale(true);
			ClippingMaskPrefab.GetComponent<MoveToMovementMask>().SetCanMove(true);
		}
	}

	void OnMouseDown(){
		collisions = 1;
		screenPoint = Camera.main.WorldToScreenPoint(transform.position);
		offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
		ClippingMaskPrefab.GetComponent<ScaleToSize>().SetCanScale(false);
		ClippingMaskPrefab.GetComponent<MoveToMovementMask>().SetCanMove(false);
	}
	
	void OnMouseDrag(){
		collisions = 1;
		// Vector3 mousePosition = new Vector3 ( Input.mousePosition.x,Input.mousePosition.y, distance);
		// Vector3 objPosition = Camera.main.ScreenToWorldPoint(mousePosition);
		// transform.position = new Vector3(objPosition.x, objPosition.y, distance);
		Vector3 cursorPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
		Vector3 cursorPosition = Camera.main.ScreenToWorldPoint(cursorPoint) + offset;
		transform.position = cursorPosition;
	}

	void OnMouseExit(){
		collisions = 0;
		Debug.Log("MOUSE EXIT");
		// clipping mask can start moving 
		// ClippingMaskPrefab.GetComponent<ScaleToSize>().SetCanScale(true);
		// ClippingMaskPrefab.GetComponent<MoveToMovementMask>().SetCanMove(true);
	}
}
