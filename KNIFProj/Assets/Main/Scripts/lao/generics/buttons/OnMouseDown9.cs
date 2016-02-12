using UnityEngine;
using System.Collections;

// simple mouse down

namespace LAO.Generic {

    public class OnMouseDown9 : MonoBehaviour {

        public string sName { get; set; }

        void Start() {
            this.sName = this.gameObject.name;
        }

        void OnMouseDown() {
            if (sName == null || sName.Equals("")) {
                sName = "NoNameYet";
            }

            // call event listener function
            Debug.Log("clicked: " + sName);

        }
    }
}