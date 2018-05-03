using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Destroys enemy when they apporach and collide with the invisible wall.
/// This does not get the user any points or credit.
/// Enemy justs simply dissapears
/// </summary>
public class WallDestroyer : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

	void OnTriggerEnter(Collider col){
		Debug.Log ("collidder check");
		if (col.gameObject.CompareTag ("Enemy")){
			Debug.Log ("collider hit");
			Destroy (col.gameObject);
		}
	}
}
