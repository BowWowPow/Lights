using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
	List<GameObject> characters = new List<GameObject>();
	// Use this for initialization
	public GameObject npcPrefab;
	private float offset;

	private float nNpcs;

	void Start () {
		nNpcs = 50.0f;
		offset = 3.0f;
		spawnNPCS();
	}
	
	// Update is called once per frame
	void Update () {

		if(Input.GetKey(KeyCode.A)){
			Debug.Log("Updating Lights");
			UpdateLights();
		}
		
	}

	public void spawnNPCS(){
		for( int i = 0; i < nNpcs; i++){
			GameObject npc = Instantiate(npcPrefab, new Vector3(Random.Range(1,100),Random.Range(1,100),0.0f), Quaternion.identity);
			characters.Add(npc);
		}
	}


	public void UpdateLights()
	{
		for(int i = 0; i < characters.Count; i++)
		{
			if(characters[i].GetComponent<npc>().npcIsAlive())
			{
				for(int k = 0; k < characters.Count; k++)
				{
					if(characters[k].GetComponent<npc>().npcIsAlive())
					{	
						float dist = characters[i].GetComponent<npc>().GetDistanceBetweenObjects(characters[k]);
						if(dist <= offset && dist != 0)
						{
							characters[i].GetComponent<npc>().TakeLight(dist, characters[k]);
						}
					}
					else
					{
						characters.Remove(characters[k]);
					}
			}
		}
		else
		{
			characters.Remove(characters[i]);
		}
		}
	}
}
