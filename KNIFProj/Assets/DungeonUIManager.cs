using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DungeonUIManager : MonoBehaviour {

	[SerializeField]
	private Text dungeonLvl;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	public void setDungeonLvl(int lvl) {
		if (dungeonLvl != null){
			dungeonLvl.text = lvl.ToString ();
		} else{
			Debug.LogWarning ("failed to update dungeonLvl text, dungeonLvl is null");
		}
	}
}
