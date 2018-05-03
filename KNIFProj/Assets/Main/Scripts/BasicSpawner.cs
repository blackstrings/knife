using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicSpawner : MonoBehaviour {

	public GameObject goToSpawn;
	public Transform spawnLocation;

	// Use this for initialization
	void Start () {
		
	}

	/// <summary>
	/// Spawn the referenced gameobject.
	/// </summary>
	public void spawn() {
		if (goToSpawn != null){
			if (spawnLocation != null){
				
				GameObject go = Instantiate (goToSpawn, this.transform);
				go.name = "enemy";
				Vector3 locale = spawnLocation.position;
				go.transform.position.Set (locale.x, locale.y, locale.z);

			} else{
				Debug.LogError ("Failed to spawn gameobject, spawnLocation is null");
			}

		} else{
			Debug.LogError ("Failed to spawn gameobject, goToSpawn is null");
		}
	}

}
