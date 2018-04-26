using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Rainkey.Network;

public class LoginUITester : MonoBehaviour {

	public GameManagerWeapon gm;
	public Text emailText;
	public Text passText;
	public Button loginBtn;

	public Button updateWeaponBtn;
	public Weapon weapon;


	// Use this for initialization
	void Start () {
		loginBtn.onClick.AddListener (userLogin);
		updateWeaponBtn.onClick.AddListener (updateWeapon);
	}

	private void log(){
		Debug.Log ("<<LoginUITester>>");
	}

	private void userLogin(){
		log ();
		gm.loginManager.login (new LoginAuth (emailText.text, passText.text, null));
	}

	private void updateWeapon(){
		log ();
		gm.saveManager.save (weapon, gm.loginManager.getLoginAuth());
	}


}
