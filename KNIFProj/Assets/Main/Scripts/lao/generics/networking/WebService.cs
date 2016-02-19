using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.Experimental.Networking;
using Newtonsoft.Json;

namespace LAO.Generic {

    //test
    public class Foo {
        public int id { get; set; }
        public string full_name { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public Foo() { }
    }

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
			//string query = "http://jsonplaceholder.typicode.com/posts";
            string query = "https://knife-example-api1.herokuapp.com/customers.json";

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


                //single json object
                /*
                Foo f = new Foo();
                f.id = 22;
                f.full_name = "tom";
                f.email = "tom@mail";
                f.phone = "9999-999";

                string jsonstr = JsonConvert.SerializeObject(f);

                Foo f2 = JsonConvert.DeserializeObject<Foo>(jsonstr);
               
                Debug.Log(f2.id);
                */
                


            }



            //Post way using unityWebRequest
            /*
            WWWForm f = new WWWForm();
            f.AddField("customer", "1");
            UnityWebRequest www = UnityWebRequest.Post(url, f);
            // www.downloadHandler = new DownloadHandlerBuffer();

            yield return www.Send();
            if (www.isError) {
                Debug.Log(www.error);
            } else {
                Debug.Log("Form uploaded complete");
                Debug.Log(www.downloadHandler.text);
            }
            */

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