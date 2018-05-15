using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Rainkey.Network;

/// <summary>
/// A test interface for calling all the server apis
/// </summary>
public class LoginUITester : MonoBehaviour{

	private MainGameController gameController;
	public Text emailText;
	public Text passText;
	public Button loginBtn;

	public Button updateWeaponBtn;
	public Button createNewUserBtn;
	public Button getRandomWeaponBtn;
	public Weapon weapon;
	public DungeonData dungeonData;


	// Use this for initialization
	void Start (){
		

		gameController = GameObject.FindGameObjectWithTag ("GameController").GetComponent<MainGameController> ();
		if (gameController == null){
			throw new UnityException ("couldn't find main game controller");
		}

		// setup the button events
		if (loginBtn != null 
			&& createNewUserBtn != null 
			&& updateWeaponBtn != null
			&& getRandomWeaponBtn != null){

			loginBtn.onClick.AddListener (userLogin);
			updateWeaponBtn.onClick.AddListener (updateWeapon);
			createNewUserBtn.onClick.AddListener (createNewUser);
			getRandomWeaponBtn.onClick.AddListener (getRandomWeapon);
		} else {
			Debug.LogWarning ("UI buttons are null");
		}


	}

	private void log (){
		Debug.Log ("<<LoginUITester>>");
	}

	private void userLogin (){
		log ();
		gameController.login (emailText.text, passText.text, null);
	}

	private void updateWeapon (){
		log ();
		//gameController.saveManager.save (weapon, gameController.loginManager.getLoginAuth());
		gameController.saveWeapon (weapon);
	}

	private void createNewUser (){
		gameController.createNewUser(emailText.text, passText.text, null);
	}

	/// <summary>
	///  when the user completes a dungeon, they get a new weapon as rewared
	/// </summary>
	private void getRandomWeapon (){
		gameController.getRandomWeapon (dungeonData);
	}


}
