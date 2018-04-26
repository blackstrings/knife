using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class NewUserAccount {

	public string email;
	public string password;
	public string password_confirmation;

	public NewUserAccount(string email, string password, string password_confirmation){
		this.email = email;
		this.password = password;
		this.password_confirmation = password_confirmation;
	}

}
