using UnityEngine;
using System.Collections;

// simple mouse down for product selections

namespace LAO.Generic {

    public class ProductDTO : MonoBehaviour {

        // store path of 3D model
        public string namePath { get; set; }

        void OnMouseDown() {
            if (name == null || name.Equals("")) {
                namePath = "NoNameYet";
            }

            // call event listener function
            Debug.Log("clicked: " + namePath);
            ProductSelectController.instance.displaySelectedProduct(this);
        }
        
    }
}