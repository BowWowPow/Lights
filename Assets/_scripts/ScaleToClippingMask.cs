using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleToClippingMask : MonoBehaviour {

	public GameObject ClippingMaskPrefab;
	public float offset;
	// Use this for initialization
	void Start () {
		offset = 4.3f;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if(ClippingMaskPrefab == null){
			Debug.Log("Cannot Find Mask");
			ClippingMaskPrefab = GameObject.FindGameObjectWithTag("ClippingMask");
		}
		transform.localScale = new Vector3(ClippingMaskPrefab.transform.localScale.x / offset,ClippingMaskPrefab.transform.localScale.y / offset,ClippingMaskPrefab.transform.localScale.z / offset);
	}
}
