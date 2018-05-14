using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rainkey.Network;

/// <summary>
/// Main game controller for accessing all services call.
/// Doesn't get destroy on load.
/// 
/// Set the environment type here which will create the correct environment for all managers.
/// </summary>
public class MainGameController : MonoBehaviour {

	public GameManagerWeapon gameManager;
	public EnvironmentType environmentType;

	// Use this for initialization
	void Start () {
		if (gameManager == null && environmentType == null){
			throw new UnityException ();
		} else{
			init ();
		}

		// this game object doens't get destroy on new scene load
		DontDestroyOnLoad (this);
	}

	// Update is called once per frame
	private void init(){
		Environments env = new Environments (environmentType);
		gameManager.init (env);
	}

	public void login(string email, string user, string pass){
		LoginAuth loginAuth = new LoginAuth(email, user, pass);
		if (loginAuth != null){
			gameManager.loginManager.login (loginAuth);
		} else{
			Debug.LogWarning ("Failed to login, loginAuth is null");
		}
	}

	public void createNewUser(string email, string user, string pass){
		LoginAuth loginAuth = new LoginAuth(email, user, pass);
		if (loginAuth != null){
			gameManager.loginManager.createUser (loginAuth);
		} else{
			Debug.LogWarning ("Failed to create new user, loginAuth is null");
		}
	}

	/// <summary>
	/// Gets the random weapon for the user. When user completes a dungeon.
	/// </summary>
	/// <param name="dungeonData">Dungeon data.</param>
	public void getRandomWeapon(DungeonData dungeonData){
		gameManager.saveManager.getRandomWeapon(dungeonData, getLoginAuth());
	}

	/// <summary>
	/// Saves the weapon.
	/// TODO not sure if we willl keep this
	/// </summary>
	/// <param name="weapon">Weapon.</param>
	public void saveWeapon(Weapon weapon){
		gameManager.saveManager.save (weapon, getLoginAuth());
	}

	private LoginAuth getLoginAuth(){
		return gameManager.loginManager.getLoginAuth ();
	}
}
