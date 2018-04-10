﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using Newtonsoft.Json;

/// <summary>
/// Prototype network caller. latest and greatest.
/// </summary>
namespace Rainkey.Network {
	
	public class Networker : MonoBehaviour
	{
	
		private string domain;
		private string loginUri;
		private string weaponUri;

		/// <summary>
		/// Stores the login token once login successfully.
		/// </summary>
		private LoginDTO loginDTO;	// stores the loginDTO

		// Use this for initialization
		void Start ()
		{
			//domain = "http://weapons-game.herokuapp.com/";
			domain = "http://localhost:3000/";

			loginUri = domain + "api/v1/login/";
			weaponUri = domain + "api/v1/weapons/";
		}

		public void updateWeapon(string weapon){
			if (loginDTO.auth_token != null) {
				StartCoroutine (updateWeaponAsync (weapon));
			} else {
				Debug.Log ("failed to update weapon, auth token null");
			}
		}

		public LoginDTO getLoginDTO(){
			return loginDTO;
		}

		public void login(string username, string password) {
			if (username != null && password != null) {
				StartCoroutine (userLogin (username, password));
			} else {
				Debug.Log ("login failed, username or password is null");
			}
		}

		private IEnumerator updateWeaponAsync(string weapon){

			// rails can post, but it may need hacking on rails side for update or target new routing for udpate
//			WWWForm f = new WWWForm ();
//			f.AddField ("weapon", weapon);
//			f.headers.Add ("Authorization", "Token token=" + loginDTO.auth_token);


			//UnityWebRequest www = UnityWebRequest.Post(weaponUri + 1, f);



			// put uses byte method
			//string = '';
			byte[] myData = System.Text.Encoding.UTF8.GetBytes(weapon);
			//byte[] testData = System.Text.Encoding.UTF8.GetBytes("helloUnity");
			UnityWebRequest www = UnityWebRequest.Put(weaponUri + 1, myData);
			www.SetRequestHeader("Authorization", "Token token=" + loginDTO.auth_token);

			// this is key for rails to know what kind of data to even think how to start parsing
			www.SetRequestHeader("Content-Type", "application/json");
			www.downloadHandler = new DownloadHandlerBuffer ();

			//test
//			Dictionary<string, string> headers = www.GetResponseHeaders();
//			for (int index = 0; index < headers.Count; index++) {
//				string item = headers [index];
//				Debug.Log (item);
//			}

//			Dictionary<string, string> headers = www.GetResponseHeaders();
//			foreach(var item in headers.Keys)
//			{
//				Debug.Log (item);
//			}

//			foreach(KeyValuePair<string, string> entry in headers)
//			{
//				// do something with entry.Value or entry.Key
//				Debug.Log("key:" + entry.Key + ", " + entry.Value);
//
//			}


			yield return www.SendWebRequest ();

			if (www.isNetworkError) {
				Debug.Log (www.error);
			} else {
				Debug.Log (www.downloadHandler.text);
			}
		}

		private IEnumerator userLogin (string username, string password)
		{

			// fill the form
			WWWForm f = new WWWForm ();
			f.AddField ("email", username);	// yeng@email.com
			f.AddField ("password", password);

			// prepare the request
			UnityWebRequest www = UnityWebRequest.Post (loginUri, f);
			www.downloadHandler = new DownloadHandlerBuffer ();

			// send the request
			yield return www.SendWebRequest ();

			// check the request
			if (www.isNetworkError) {
				Debug.Log (www.error);
			} else {
				// textOutput_gui.text = "www processing complete";
				Debug.Log ("Form uploaded complete");

				// the send back information will be available in the downloadhandler text
				Debug.Log (www.downloadHandler.text);

				//convert deserialized json str arrays, into tru objects
				string returnedJsonData = www.downloadHandler.text;
				//Debug.Log(www.downloadHandler.text);
                
				// list deserialize
				//List<Foo> foos = JsonConvert.DeserializeObject<List<Foo>>(returnedJsonData);

				// single object deserialize
				loginDTO = JsonConvert.DeserializeObject<LoginDTO>(returnedJsonData);
				Debug.Log("deserialize complete: " + loginDTO.auth_token);
//                Debug.Log("converting json into tru objects >> now testing read from customer 1");
//                Foo f = foos[0];
//                Debug.Log("#Name: " + f.full_name 
//                    + " #id: " + f.id
//                    + " #email: " + f.email
//                    + " #phone: " + f.phone	
//                    );

			}
		}

	}

}