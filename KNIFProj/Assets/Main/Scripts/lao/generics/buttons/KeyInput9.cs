using UnityEngine;

// gameObject.transform.Translate(new Vector3(-1,0,0));

namespace LAO.Generic {

    /// <summary>
    /// Key input examples
    /// </summary>
    public class KeyInput9 : MonoBehaviour {

        public GameObject go;

        void Update() {
            // Movement

            if (Input.GetKeyDown(KeyCode.LeftArrow)) {
                go.transform.parent.transform.Translate(new Vector3(-1, 0, 0));
            }
            if (Input.GetKeyDown(KeyCode.RightArrow)) {
                go.transform.parent.transform.Translate(new Vector3(1, 0, 0));
            }
            if (Input.GetKeyDown(KeyCode.UpArrow)) {
                go.transform.parent.transform.Translate(new Vector3(0, 1, 0));
            }
            if (Input.GetKeyDown(KeyCode.DownArrow)) {
                go.transform.parent.transform.Translate(new Vector3(0, -1, 0));
            }

            // color change

            if (Input.GetKeyDown(KeyCode.Y)) {
                go.GetComponent<Renderer>().material.color = Color.yellow;
            }
            if (Input.GetKeyDown(KeyCode.M)) {
                go.GetComponent<Renderer>().material.color = Color.magenta;
            }
            if (Input.GetKeyDown(KeyCode.C)) {
                go.GetComponent<Renderer>().material.color = Color.cyan;
            }
            if (Input.GetKeyDown(KeyCode.K)) {
                go.GetComponent<Renderer>().material.color = Color.black;
            }
        }
    }
}
