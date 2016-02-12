using UnityEngine;
using System.Collections;

namespace LAO.Generic {

    public class MouseEvent : MonoBehaviour {

        // Use this for initialization
        void Start() {

        }

        void OnMouseDown() {
            Debug.Log("mouse down");
        }

        void OnMouseUp() {
            Debug.Log("mouse up");
        }
    }
}
