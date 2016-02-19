using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.Experimental.Networking;
using Newtonsoft.Json;


namespace LAO.Generic {

   

    public class WebService : MonoBehaviour {

		public Text textOutput_gui;

		// Use this for initialization
		void Start () {
		
		}
		
		// Update is called once per frame
		void Update () {
		
		}
        
		//test call
		public void testServerCall(){
			//string query = "http://xailao.com/games/poplopoly/retreive.php?query=top5";

			//RUBY
			//string query = "localhost:3000";
			//string query = "http://jsonplaceholder.typicode.com/posts";
            string query = "https://knife-example-api1.herokuapp.com/customers";

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



            //old www get method - working
			/*
            WWW www = new WWW(url);
            yield return www;
            

            if (!string.IsNullOrEmpty(www.error)) {
                Debug.Log(www.error);
            } else {
                Debug.Log("Must click on debug lines below in console to see the whole json string");
                Debug.Log(www.text);

                //convert deserialized json str arrays, into tru objects
                string jstr = www.text;
                List<Foo> foos = JsonConvert.DeserializeObject<List<Foo>>(jstr);

                Debug.Log("converting json into tru objects >> now testing read from customer 1");
                Foo f = foos[0];
                Debug.Log("#Name: " + f.full_name 
                    + " #id: " + f.id
                    + " #email: " + f.email
                    + " #phone: " + f.phone
                    );

            }
			*/
			 


            //Post way using unityWebRequest
            
            WWWForm f = new WWWForm();
            //f.AddField("id", "1");
			f.AddField("full_name", "Kimmy");
			f.AddField("email", "kimmy@hotmail.com");
			f.AddField("phone", "222-0001");


			Dictionary<string, string> hash = new Dictionary<string, string>();

			hash.Add("full_name", "Kimmy");
			hash.Add("email", "Kimmy@hotmail.com");
			hash.Add("phone", "222-3333");
			hash.Add("customer", "newCustom");

			string jstr = "{\"customer\":[{\"full_name\":\"tom\",\"email\":\"tom@hotmail.com\",\"phone\":\"333-3333\"}]}";

			//f.AddField("created_at", System.DateTime.Now);
			//f.AddField("updated_at", System.DateTime.Now);
			//Debug.Log(System.DateTime.Now);

			//2016-02-19 03:03:33

            UnityWebRequest www = UnityWebRequest.Post(url, jstr);
			www.SetRequestHeader("Content-Type", "application/json");
            www.downloadHandler = new DownloadHandlerBuffer();

            yield return www.Send();
            if (www.isError) {
                Debug.Log(www.error);
            } else {
				textOutput_gui.text = "login failed!";
                Debug.Log("Form uploaded complete");
                Debug.Log(www.downloadHandler.text);
            }

            

                //the php file is called and whatever it echose back will be put into www.text
                //go_scoreTxt.gameObject.GetComponent<Text>().text = www.text;



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