using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomToMaskSize : MonoBehaviour {

	public GameObject clippingMask;
	public float cm_x;
	public float camDistRatio;
	// Use this for initialization
	void Start () {
		camDistRatio = 1.0f;
	}

	void FixedUpdate(){
		// When the second clipping window comes in, then this will work nicely.. Maybe.
		cm_x = clippingMask.transform.localScale.x * 2;
		transform.position = new Vector3(clippingMask.transform.position.x,clippingMask.transform.position.y,-cm_x);
	}

}
