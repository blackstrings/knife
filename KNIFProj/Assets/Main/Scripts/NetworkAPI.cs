using System.Collections;
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
		loginBtn.onClick.AddListener (login);
		updateWeaponBtn.onClick.AddListener (updateWeapon);
	}
	
	private void login(){
		if (networker) {
			networker.login(username.text, password.text);
		}
	}

	private void updateWeapon(){
		if (networker.getLoginDTO ().auth_token != null) {
			networker.updateWeapon ("{\"rarity\": 7, \"speed\": 7 }");
		} else {
			Debug.Log ("auth token null");
		}
	}

//	public void updateWeapon(Weapon weapon){
//		networker.updateWeapon (weapon);
//	}

	// TODO may not need
	public LoginDTO getLoginDTO(){
		LoginDTO dto = null;
		if(networker){
			dto = networker.getLoginDTO ();
		}
		return dto;
	}
}
