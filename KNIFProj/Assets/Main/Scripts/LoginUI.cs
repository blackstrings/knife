using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Rainkey.Network;

public class LoginUI : MonoBehaviour {

	public Text emailText;
	public Text passText;
	public Button loginBtn;
	public GameManagerWeapon gm;

	// Use this for initialization
	void Start () {
		loginBtn.onClick.AddListener (userLogin);
	}

	private void userLogin(){
		gm.loginManager.login (new LoginAuth (emailText.text, passText.text, null));
	}

	// Update is called once per frame
	void Update () {
		
	}
}
