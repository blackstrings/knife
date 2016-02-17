using UnityEngine;
using System.Collections;

namespace LAO.Generic {

    public class JavascriptCommunicationOnClick : MonoBehaviour {

        // listen for a mouse up event on this gameObject, which this script is attached to
        void OnMouseUp() {
            //Application.ExternalCall("JSFunctionOnPage");

            // call out to a javascript function - can pass any number of parameters or none
            // javascript function should be present on the HTML page for this to work
            // 
            Application.ExternalCall("JSFunctionOnPage", "Hello from Unity");
        }


        //for testing only
        /*
        void Update(){

            //listen for S key
            if(Input.GetKeyDown(KeyCode.S)){

                // reference text GameObject in view
                GameObject go = GameObject.Find("TextObject");

                //
                go.GetComponent<JavascriptCommunicationIncoming>().changeText("text changed by pressing S test");
            }
        }
        */
    }
}