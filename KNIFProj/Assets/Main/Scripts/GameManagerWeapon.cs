using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rainkey.Network;

/// <summary>
/// Inits all core managers.
/// </summary>
public class GameManagerWeapon : MonoBehaviour {

	// all core managers here
	public LoginManager loginManager;
	public SaveManager saveManager;

	// Use this for initialization
	void Start () {

		// check all managers are injected
		if(loginManager == null || saveManager == null){
			throw new UnityException("one or more managers are null");
		}

	}

	/// <summary>
	/// Handles initiating all the core managers in this method.
	/// </summary>
	/// <param name="env">Env.</param>
	public void init(Environments env){
		if(env != null){
			// all core managers get the environement and should be init here
			loginManager.init (env);
			saveManager.init(env);
		}
	}

	/// <summary>
	/// User login
	/// </summary>
	/// <param name="email">Email.</param>
	/// <param name="user">User.</param>
	/// <param name="pass">Pass.</param>
	public void login(string email, string user, string pass){
		loginManager.login (new LoginAuth (email, pass, user));
	}

	/// <summary>
	/// Update weapon. If user loses a weapon or merges a weapon, they lose th weapo
	/// </summary>
	/// <param name="weapon">Weapon.</param>
//	public void saveWeapon(Weapon weapon){
//		LoginAuth loginAuth = loginManager.getLoginAuth ();
//		if (loginAuth != null){
//			saveManager.save(weapon, loginAuth);
//		} else{
//			Debug.Log ("fail to save weapon, loginAuth is null");
//		}
//	}

	/// <summary>
	/// Dungeons the complete. get new weapons for the user.
	/// </summary>
	public void getRandomWeapon(DungeonData dungeonData){
		LoginAuth loginAuth = loginManager.getLoginAuth ();
		if (loginAuth != null){
			saveManager.getRandomWeapon (dungeonData, loginAuth);
		} else{
			Debug.Log ("fail to get new weapons for user, loginAuth is null");
		}
	}

}