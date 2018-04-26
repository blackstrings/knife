﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Rainkey.Network;

public class NetworkAPI : MonoBehaviour {

	public Networker networker;

	//buttons
	public Text username;
	public Text password;
	public Button loginBtn;
	public Button updateWeaponBtn;

	// Use this for initialization
	void Start () {
		// fat arrow method
//		loginBtn.onClick.AddListener (() => {
//			networker.login(username.text, password.text);
//		});

		// simpler method
		loginBtn.onClick.AddListener (userLogin);
		updateWeaponBtn.onClick.AddListener (updateWeapon);
	}

	private void userLogin(){
		if (networker) {
			networker.userLogin(username.text, password.text);
		}
	}

	private void updateWeapon(){
		if (networker.getLogin().auth_token != null) {
			// must use escape characters
			networker.updateWeapon ( "{\"weapon\": {\"rarity\": 99, \"speed\": 99 }}" );

			// ex: this won't work, rails will not recognize the json string, and treat it just like
			// a regular string
			// networker.updateWeapon ( "{weapon: {rarity: 99, speed: 99 }}" );
		} else {
			Debug.Log ("auth token null");
		}
	}

//	public void updateWeapon(Weapon weapon){
//		networker.updateWeapon (weapon);
//	}

	// TODO may not need
	public LoginAuth getLogin(){
		LoginAuth login = null;
		if(networker){
			login = networker.getLogin ();
		}
		return login;
	}
}
