using UnityEngine;
using System.Collections;

namespace LAO.Generic {

    public class JavascriptCommunicationIncoming : MonoBehaviour {

        public GameObject go;

        //to implement a singleton class
        //static public JavascriptCommunicationIncoming instance;

        private string PageData;


        void Awake() {
            // to implement a singleton
            /*
            DontDestroyOnLoad(gameObject);
            instance = this;   
            */
        }


        void Start() {
            go = gameObject;
        }
        // Update is called once per frame
        public void changeText(string str) {
            //Application.ExternalCall("JSFunctionOnPage");

            // you can make multiple calls
            if (string.IsNullOrEmpty(str)) {
                str = "changeText called by pressing S";
            }
            go.GetComponent<TextMesh>().text = str;
        }


    }

}