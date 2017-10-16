using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToMaskCenter : MonoBehaviour {
	private GameObject ClippingMaskPrefab;
	public float speed;
	// Use this for initialization
	void Start () {
		speed = 4f;
		ClippingMaskPrefab = GameObject.FindGameObjectWithTag("ClippingMask");
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if(ClippingMaskPrefab == null){
			Debug.Log("Cannot Find Mask");
			ClippingMaskPrefab = GameObject.FindGameObjectWithTag("ClippingMask");
		}
		float step = speed * Time.deltaTime;
 		transform.position = Vector3.Lerp(transform.position, ClippingMaskPrefab.transform.position, step);

 		
		//transform.position = Vector3.MoveTowards(transform.position, new Vector3(50.0f,50.0f,0.0f), step);
        //transform.position = Vector3.MoveTowards(transform.position, ClippingMaskPrefab.transform.position, step);
        // This is still updating the position. I need it to move to 0.0.0 rather than to the mask position?? 
        // That should be working... 
        // Do I need to parent this object with the clipping window?
        //   -- No because then it will fuck the positioning when I move the clipping window.

	}
}
