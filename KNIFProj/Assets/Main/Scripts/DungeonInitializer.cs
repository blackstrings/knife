using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonInitializer : MonoBehaviour{

	public BasicSpawner basicSpawner;
	public DungeonUIManager dungeonUI;

	// Use this for initialization
	void Start (){
		if (basicSpawner == null && dungeonUI == null){
			Debug.LogWarning ("basicSpawner or dungeonUI is null");
		}

		// TODO test force start
		int dugeonLevel = 1;
		init (dugeonLevel);
	}

	/// <summary>
	/// Something should init this
	/// </summary>
	public void init (int dungeonLevel){

		// update UI
		dungeonUI.setDungeonLvl(dungeonLevel);


		spawn ();

	}

	/// <summary>
	/// Start spawning enemy wave
	/// </summary>
	private void spawn (){
		if (basicSpawner != null){
			basicSpawner.spawn ();
		} else{
			Debug.Log ("failed to init dungeon, basicSpawner is null");
		}
	}

	public void attack(){
		Debug.Log ("Attacking");
	}
}
