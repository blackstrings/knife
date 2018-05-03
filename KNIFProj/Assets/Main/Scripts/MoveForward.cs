using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour {

	public bool canMove;
	public float speed;
	public Vector3 moveDirection;

	// Use this for initialization
	void Start () {
		if (speed <= 0){
			speed = .2f;
		}
	}
	
	void FixedUpdate(){
		if (canMove == true){
			
			gameObject.transform.Translate(moveDirection * (Time.deltaTime * speed));
		}
	}
}
