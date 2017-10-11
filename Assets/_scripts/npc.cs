using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class npc : MonoBehaviour {
	private float lightLevel;
	private float perferedLightLevel;
	private float distance;
	private float lightOutNumber;
	private float reservedLightAmount;
	private float giveLightPercent;
	private bool isNPCAlive;
	public GameObject circle;

	// Use this for initialization
	void Start () {
		isNPCAlive = true;
		lightLevel = Random.Range(2,10);
		giveLightPercent = Random.Range(0.0f,0.6f);
		lightOutNumber = 5f;
		transform.localScale = new Vector3(lightLevel,lightLevel,lightLevel);
		distance = 10;
		MyPriority();
		circle.gameObject.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		if(lightLevel <= lightOutNumber){
			isNPCAlive = false;
		}
	}

	public void MyPriority(){
		perferedLightLevel = Random.Range(40,90);
	}

	public void TakeLight(float dist, GameObject obj){
		dist = dist / 100;
		float lightRemoved = obj.GetComponent<npc>().GetReservedAmountOfLight() * dist;
		lightLevel += lightRemoved * dist;
		SetSize();
		obj.GetComponent<npc>().RemoveLight(lightRemoved);
	}

	public void GiveLight(GameObject obj){
		
	}

	// Some way of always loosing light energy. 
	// Could build up and grow a group to go to other light circle groups.
	// Could do different colonies of light groups. 
	

	public bool npcIsAlive(){
		return isNPCAlive;
	}

	public void SetSize(){
		Debug.Log("Setting Size");
		transform.localScale = new Vector3(lightLevel,lightLevel,lightLevel);
	}

	public void RemoveLight(float lightRemoved){
		lightLevel -= lightRemoved;

	}

	void OnMouseDrag(){
		circle.gameObject.SetActive(true);
		Vector3 mousePosition = new Vector3 ( Input.mousePosition.x,Input.mousePosition.y, distance);
		Vector3 objPosition = Camera.main.ScreenToWorldPoint(mousePosition);
		transform.position = objPosition;
	}

	void OnMouseUp(){
		circle.gameObject.SetActive(false);
	}

	public void ReservedAmountOfLight(){
		reservedLightAmount = lightLevel * giveLightPercent;
	}

	public float GetReservedAmountOfLight(){
		return reservedLightAmount;	
	}

	public void UpdateStatus(){
		// Switch Case For What the NPC needs to do next.
		// This could be take into a thing were I set 
		// HOW MUCH LIGHT I'M ALLOWED TO GIVE AWAY.
		// This would never be zero. 
		// Objects that go away are lost to the player forever. 
		// The player is allowed to re-arrange all the characters on the screen to keep them alive.


		
	}

	public float GetDistanceBetweenObjects(GameObject c1){
		// Gets called by something to see how far an object is away from it. 
		// This value is then used to make a % of the total light a NPC can give or take.
		// from the reserve amount of light.
		float dist = Vector3.Distance(c1.transform.position, transform.position);
		return dist;
	}
}
