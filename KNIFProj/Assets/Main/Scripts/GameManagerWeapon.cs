using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rainkey.Network;

public class GameManagerWeapon : MonoBehaviour {

	public LoginManager loginManager;
	public SaveManager saveManager;

	// Use this for initialization
	void Start () {
		Environments env = new Environments ("stage");
		loginManager.init (env);
		saveManager.init (env);
		DontDestroyOnLoad(this);
	}
	
	public void login(string email, string user, string pass){
		loginManager.login (new LoginAuth (email, pass, user));
	}

	public void saveWeapon(Weapon weapon){
		LoginAuth loginAuth = loginManager.getLoginAuth ();
		if (loginAuth != null){
			saveManager.save(weapon, loginAuth);
		} else{
			Debug.Log ("fail to save weapon, loginAuth is null");
		}
	}

}
