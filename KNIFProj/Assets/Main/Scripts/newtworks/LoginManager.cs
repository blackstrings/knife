﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using Newtonsoft.Json;

namespace Rainkey.Network {

	/// <summary>
	/// Handles logging and carries the loginAuth.
	/// 
	/// Any calls that wish to communicate to the network should request the loginAuth.
	/// </summary>
	public class LoginManager : MonoBehaviour{

		private LoginAuth loginAuth;
//		private string loginURI;

		private string loginUri;
		private string createUserUri;

		// Use this for initialization
		void Start (){
			//domain = "http://weapons-game.herokuapp.com/";
//			string domain = "http://localhost:3000/";
//			string loginService = "api/v1/login/";
//			loginURI = domain + loginService;
		}

		public void init(Environments env){
			loginUri = env.getUri (URI.LOGIN);
			createUserUri = env.getUri (URI.CREATE_NEW_USER);
		}

		/// <summary>
		/// Main login api.
		/// </summary>
		/// <param name="loginAuth">Login auth.</param>
		public void login (LoginAuth loginAuth){
			if (loginAuth != null){
				StartCoroutine (beginLogin (loginAuth));
			} else{
				Debug.Log ("fail to login, loginAuth is null");
			}
		}

		public void createUser(LoginAuth loginAuth){
			StartCoroutine (beginNewUserCreation (loginAuth));
		}

		private IEnumerator beginNewUserCreation (LoginAuth loginAuth){

			// WWWForm worked with creating new user, on rails side the escaped charc will be removed so that rails will work
			// if rails is expecting the data to be one layed nested, fix an if else on rails registeration side
			// by not requiring the "user"
			// first key param i.e. { "user": {"email": "yeng23@email.com", "password": "password", "password_confirmation": "password" } }

			// fill the form - with Post on rail side, using the form, the escaped characters are removed which is good
			WWWForm form = new WWWForm ();
			form.AddField ("email", loginAuth.email);
			form.AddField ("password", loginAuth.pass);
			form.AddField ("password_confirmation", loginAuth.pass);

			UnityWebRequest www = UnityWebRequest.Post (createUserUri, form);
			www.downloadHandler = new DownloadHandlerBuffer ();

			// no need for to set these as these will only cause rails to fail to parse the string when using post
			// or use the default content type by not setting it at all
			// www.SetRequestHeader("Content-Type", "application/json");
			//www.SetRequestHeader("Content-Type", "application/x-www-form-urlencoded");


			yield return www.SendWebRequest ();

			// response - check the callback request
			if (www.isNetworkError){
				Debug.Log (www.error);
			} else{
				string returnedJsonData = www.downloadHandler.text;

				// to handle the json deserialize into an object
				NetworkResponses rd = JsonUtility.FromJson<NetworkResponses>(returnedJsonData);


				// convert the response from json into real object temp auth
				//LoginAuth tempAuth = JsonConvert.DeserializeObject<LoginAuth>(returnedJsonData);

				// store the login auth for later
				// this.loginAuth = loginAuth;
				// this.loginAuth.auth_token = tempAuth.auth_token;
				Debug.Log ("creation success");
				Debug.Log (rd.email[0]);
			}
		}

		/// <summary>
		/// Gets a deep clone copy of the login auth if exist.
		/// </summary>
		/// <returns>The login auth.</returns>
		public LoginAuth getLoginAuth(){
			LoginAuth loginClone = null;
			if (loginAuth != null){
				loginClone = new LoginAuth (loginAuth.email, loginAuth.pass, loginAuth.user);
				loginClone.auth_token = loginAuth.auth_token;
			} else{
				Debug.LogWarning ("Failed to get login, loginAuth is null");
			}
			return loginClone;
		}	


		private IEnumerator beginLogin (LoginAuth loginAuth){

			// fill the form
			WWWForm form = new WWWForm ();
			form.AddField ("email", loginAuth.email);
			form.AddField ("password", loginAuth.pass);

			// prepare the request
			UnityWebRequest www = UnityWebRequest.Post (loginUri, form);
			www.downloadHandler = new DownloadHandlerBuffer ();

			yield return www.SendWebRequest ();

			// response - check the callback request
			if (www.isNetworkError){
				Debug.Log (www.error);
			} else{
				string returnedJsonData = www.downloadHandler.text;

				// convert the response from json into real object temp auth
				LoginAuth tempAuth = JsonConvert.DeserializeObject<LoginAuth>(returnedJsonData);

				// store the login auth for later
				this.loginAuth = loginAuth;
				this.loginAuth.auth_token = tempAuth.auth_token;
				Debug.Log ("login success");
				Debug.Log (loginAuth.auth_token);
			}

			// after login inform a global state login is successful
		}

	}


}