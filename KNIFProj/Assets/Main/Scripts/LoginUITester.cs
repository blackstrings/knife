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
	public Button createNewUserBtn;
	public Button getRandomWeaponBtn;
	public Weapon weapon;
	public DungeonData dungeonData;


	// Use this for initialization
	void Start () {
		loginBtn.onClick.AddListener (userLogin);
		updateWeaponBtn.onClick.AddListener (updateWeapon);
		createNewUserBtn.onClick.AddListener (createNewUser);
		getRandomWeaponBtn.onClick.AddListener (getRandomWeapon);

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

	private void createNewUser(){
		gm.loginManager.createUser(new LoginAuth (emailText.text, passText.text, null));
	}

	/// <summary>
	///  when the user completes a dungeon, they get a new weapon as rewared
	/// </summary>
	private void getRandomWeapon(){
		gm.saveManager.getRandomWeapon (dungeonData, gm.loginManager.getLoginAuth ());
	}


}
