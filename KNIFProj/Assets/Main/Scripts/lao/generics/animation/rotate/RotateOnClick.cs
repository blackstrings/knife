using UnityEngine;
using System.Collections;

namespace LAO.Generic {

    public class RotateOnClick : MonoBehaviour {

        public GameObject go;
        public float speed = 2f;
        private bool canRotate = true;

        // Use this for initialization
        void Awake() {

            //if go is not assigned in the inspector
            if (go == null) {
                // assign the game object this component is currently attach to
                go = this.gameObject;

                StartCoroutine(animate(speed));
            }
        }

        IEnumerator animate(float time) {
            while (canRotate) {

                //spin
                go.transform.Rotate(new Vector3(0, -1, 0) * speed * Time.deltaTime);
                //required for using coroutine
                yield return null;

            }
            //this script plays this when done
            //do something
        }

        // Update is called once per frame
        /*
        void Update () {
            if(canRotate)
            go.transform.Rotate(new Vector3 (0, -1, 0) * speed * Time.deltaTime);
        }
        */

        void OnMouseUp() {
            canRotate = !canRotate;
            if (canRotate) {
                //start animation again
                StartCoroutine(animate(speed));
            }
        }
    }
}