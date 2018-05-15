using System.Collections;
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
	public class SaveManager : MonoBehaviour{

		// weapon save uri
		private string saveWeaponUri;
		private string createRandomWeaponUri;

		/// <summary>
		/// only GameManager should call this method at instantiation.
		/// </summary>
		/// <param name="env">Env.</param>
		public void init(Environments env){
			saveWeaponUri = env.getUri (URI.WEAPON);
			createRandomWeaponUri = env.getUri (URI.CREATE_RANDOM_WEAPON);

			if (!validateUris ()){
				Debug.LogWarning ("uris are null or empty");
			}
		}

		/// <summary>
		/// Returns true of all URIs are valid and not empty or null
		/// </summary>
		private bool validateUris(){
			bool result = true;
			if(createRandomWeaponUri == null || createRandomWeaponUri == ""){
				Debug.LogError("createRandomWeaponUri is empty or null");
				result = false;
			}
			if (saveWeaponUri == null || saveWeaponUri == ""){
				Debug.LogError("saveWeaponUri is empty or null");
				result = false;
			}
			return result;
		}

		/// <summary>
		/// Main login api. -- Remove save weapon we no longer need to save
		/// </summary>
		/// <param name="loginAuth">Login auth.</param>
		public void save (Weapon weapon, LoginAuth loginAuth){
			if (loginAuth != null){
				StartCoroutine (beginSave (weapon, loginAuth));
			} else{
				Debug.Log ("fail to save weapon, loginAuth is null");
			}
		}
			

		private IEnumerator beginSave (Weapon weapon, LoginAuth loginAuth){
			WeaponDTO dto = weapon.serialize ();
			string weaponJson = JsonUtility.ToJson (weapon);
			Debug.Log (weaponJson);
			byte[] weaponJsonByte = System.Text.Encoding.UTF8.GetBytes(weaponJson);
			//byte[] testData = System.Text.Encoding.UTF8.GetBytes("helloUnity");
			UnityWebRequest www = UnityWebRequest.Put(saveWeaponUri + weapon.id, weaponJsonByte);
			www.SetRequestHeader("Authorization", "Token token=" + loginAuth.auth_token);

			// this is key for rails to know what kind of data to even think how to start parsing
			www.SetRequestHeader("Content-Type", "application/json");
			www.downloadHandler = new DownloadHandlerBuffer ();

			yield return www.SendWebRequest ();

			if (www.isNetworkError) {
				Debug.Log (www.error);
			} else {
				Debug.Log("weapon update success");
				// Debug.Log (www.downloadHandler.text);

				NetworkResponses rd = JsonUtility.FromJson<NetworkResponses>(www.downloadHandler.text);
				Debug.Log (rd.success [0]);
			}
		}

		public void getRandomWeapon(DungeonData dungeonData, LoginAuth loginAuth){
			if (loginAuth != null){
				Debug.Log ("begin get weapon");
				StartCoroutine (beginGetRandomWeapon (dungeonData, loginAuth));
			} else{
				Debug.Log ("fail to get random weapon, loginAuth is null");
			}
		}

		private IEnumerator beginGetRandomWeapon (DungeonData dungeonData, LoginAuth loginAuth){

			// when using Post rest calls, use a form. 
			// Note: on rails side, make sure to put an if else around the wrapper object
			WWWForm form = new WWWForm ();
			form.AddField ("dungeon_level", dungeonData.dungeon_level);
			form.AddField ("experience_points", dungeonData.experience_points);

			if (createRandomWeaponUri == null || createRandomWeaponUri == ""){
				Debug.LogError ("createRandomWeaponUri is empty or null");
			} else{
				Debug.Log ("creating new weapon from server");
			}

			UnityWebRequest www = UnityWebRequest.Post(createRandomWeaponUri, form);
			www.SetRequestHeader("Authorization", "Token token=" + loginAuth.auth_token);

			// NOte: for post, do not set the header content-type (only do it for put)
			// this is key for rails to know what kind of data to even think how to start parsing
			//www.SetRequestHeader("Content-Type", "application/json");
			www.downloadHandler = new DownloadHandlerBuffer ();

			yield return www.SendWebRequest ();

			if (www.isNetworkError) {
				Debug.Log (www.error);
			} else {
				Debug.Log("weapon update success: following is the server log");
				Debug.Log (www.downloadHandler.text);

				//NetworkResponses rd = JsonUtility.FromJson<NetworkResponses>(www.downloadHandler.text);
				//Debug.Log (rd.success [0]);
			}
		}

	}


}