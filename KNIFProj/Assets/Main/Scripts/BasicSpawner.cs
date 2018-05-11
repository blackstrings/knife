using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Spawns the gameobject, enemy
/// </summary>
public class BasicSpawner : MonoBehaviour {

	public GameObject gameObjectToSpawn;
	public Transform spawnLocation;

	/// assigned at runtime after the enemy spawns
	public EnemyData enemyData;

	// Use this for initialization
	void Start () {
		
	}

	/// <summary>
	/// Spawn the referenced gameobject.
	/// </summary>
	public void spawn() {
		if (gameObjectToSpawn != null){
			if (spawnLocation != null){
				
				GameObject go = Instantiate (gameObjectToSpawn, this.transform);
				go.name = "enemy";
				Vector3 locale = spawnLocation.position;
				go.transform.position.Set (locale.x, locale.y, locale.z);

				// TODO set the enemy data specs

				// assign the enemy data



			} else{
				Debug.LogError ("Failed to spawn gameobject, spawnLocation is null");
			}

		} else{
			Debug.LogError ("Failed to spawn gameobject, goToSpawn is null");
		}
	}

}
