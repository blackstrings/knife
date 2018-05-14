using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Rainkey.Network;

/// <summary>
/// The real login UI
/// </summary>
public class LoginUI : MonoBehaviour {

	public Text emailText;
	public Text passText;
	public Button loginBtn;
	public Button createNewUserBtn;

	// set at runtime
	private MainGameController controller;

	// Use this for initialization
	void Start () {
		controller = GameObject.FindGameObjectWithTag ("GameController").GetComponent<MainGameController>();
		if (controller == null){
			throw new UnityException ("couldn't find main game controller");
		} else{

			// setup the button events
			if (loginBtn != null && createNewUserBtn != null){
				loginBtn.onClick.AddListener (userLogin);
				createNewUserBtn.onClick.AddListener (createNewUser);
			}
		}
	}

	// the button click calls these
	private void userLogin(){
		controller.login (emailText.text, passText.text, null);
	}

	private void createNewUser(){
		
	}

}
