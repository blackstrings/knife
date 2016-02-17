using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace LAO.Generic {
	public class WebService : MonoBehaviour {

		// Use this for initialization
		void Start () {
		
		}
		
		// Update is called once per frame
		void Update () {
		
		}

		public Text text_input_go;

		//test call
		public void testServerCall(){
			//string query = "http://xailao.com/games/poplopoly/retreive.php?query=top5";

			//RUBY
			//string query = "localhost:3000";
			string query = "http://jsonplaceholder.typicode.com/posts";

			//string query = "http://demo.app/items/unityItems";
			StartCoroutine(sendQuery(query));
		}

		//the return data is forwarded to the gameManager state
		IEnumerator sendQuery (string query) {
			/*
	 	url = "www.xailao.com/game/popop/update.php?" +
	 	"username" + username +
	 	"password" + password +
	 	"score" + level;
	 	*/
			
			//url = "www.xailao.com/game/popop/retrieve.php";
			
			//show this text while loading
			//go_scoreTxt.gameObject.GetComponent<Text>().text = "Loading . . .";
			
			//string url = "http://xailao.com/games/poplopoly/retreive.php?query=top10";
			string url = query;
			
			WWW www = new WWW(url);
			yield return www;
			
			//the php file is called and whatever it echose back will be put into www.text
			//go_scoreTxt.gameObject.GetComponent<Text>().text = www.text;

			Debug.Log("Must click on debug lines below in console to see the whole json string");
			Debug.Log(www.text);
			
			//use somethign to capture the data
			//GameService.setWebReturnedData(www.text);
			//GameService.setWebCallStatus(true);	//web is done calling
		}

		void OnMouseUp(){
			Debug.Log ("I was clicked");
			testServerCall ();
		}
		
	}
}