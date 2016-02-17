using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

namespace LAO.Test{

    /// <summary>
    /// How unity communicates to other server
    /// </summary>
    public class WWWNetwork : MonoBehaviour {

		public Text textInput_go;

        //private string serverURL = "https://mydomain.com/getData.php";
		//private string serverURL = "https://fast-cove-55987.herokuapp.com/blogs.json";
		//private string serverURL = "https://fast-cove-55987.herokuapp.com/blogs/1.json";
		//private string serverURL = "http://jsonplaceholder.typicode.com/posts";
		//private string serverURL = "https://knife-example-api1.herokuapp.com/customers.json";
		private string serverURL = "http://xailao.com/games/poplopoly/retreive.php?query=top5";


		string jsonStr { get; set; }
        List<string> data;

        void Start() {
			serverURL = "localhost:3000";
            data = new List<string> { "19532", "19531", "19525", "19572" }; //actual test data
        }

        IEnumerator getDataFromServer(string id) {

            //use the wwwForm for post
            // set as many key,values you want into wwwform
            //server will use post to retrieve the stored info
            WWWForm form = new WWWForm();

            form.AddField("cid", id);

            //use www to send the form to the server
            WWW w = new WWW(serverURL, form);

            yield return w;

            if (!string.IsNullOrEmpty(w.error)) {
                Debug.Log(w.error);
            } else {
                //pass 
                this.GetComponent<Text>().text = w.text;
                jsonStr = w.text;
                displayItem();
            }

        }

		IEnumerator getTestDataFromServer() {

			//use the wwwForm for post
			// set as many key,values you want into wwwform
			//server will use post to retrieve the stored info
			WWWForm form = new WWWForm();
			form.AddField("username", "testUser");
			//form.AddField("token", "tokenValue");


			//TEST with headers
			int id = 1;
			string pw = "1";
			string json = "{\"id\":\"" + id + "\", \"userId\":\"" + pw + "\"}";
			Dictionary<string, string> postHeader = new Dictionary<string, string>();
			postHeader.Add("Content-Type", "application/json");

			//use www to send the form to the server
			//WWW w = new WWW(serverURL, System.Text.Encoding.UTF8.GetBytes(json), postHeader);
			WWW w = new WWW(serverURL, form);

			yield return w;

			if (!string.IsNullOrEmpty(w.error)) {
				Debug.Log(w.error);
			} else {
				//pass 
				this.GetComponent<Text>().text = w.text;
				jsonStr = w.text;
				displayItem();
			}

		}

        private void displayItem() {
            //JObject jObj = JObject.Parse(jsonStr);
			textInput_go.text = jsonStr;

        }

        ///If you want to toggle between a list of test data
        /// ---------------------------- to test toggle between avaialble data
        private int currentData;

		public void testDataRequest(){
			StartCoroutine(getTestDataFromServer());
		}

        public void nextData() {
            if (currentData < data.Count - 1) {
                currentData++;
            } else {
                currentData = 0;
            }

            StartCoroutine(getDataFromServer(data[currentData]));
        }

        public void previousData() {
            if (currentData > 0) {
                currentData--;
            } else {
                currentData = data.Count - 1;
            }

            StartCoroutine(getDataFromServer(data[currentData]));
        }
    }
}