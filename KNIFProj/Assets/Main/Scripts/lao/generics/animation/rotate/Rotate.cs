using UnityEngine;
using System.Collections;


namespace LAO.Generic {

    public class RotateContinuously : MonoBehaviour {
        private GameObject go;
        public float speed = 50f;
        public bool autoRotate;
        public bool bounceRotate;
        public float bounceSpeed = 10f;
        private bool rotateR;

        void Start() {
            go = this.gameObject;
        }

        void Update() {

            if (autoRotate) {

                if (bounceRotate) {

                    // bounce rotate
                    if (rotateR) {
                        go.transform.Rotate(new Vector3(0, 1, 0) * speed * Time.deltaTime);
                    } else {
                        go.transform.Rotate(new Vector3(0, -1, 0) * speed * Time.deltaTime);
                    }

                    if (go.transform.rotation.y >= .5) {
                        rotateR = false;
                    }
                    if (go.transform.rotation.y <= -.5) {
                        rotateR = true;
                    }

                } else {

                    // just rotate
                    go.transform.Rotate(new Vector3(0, 1, 0) * speed * Time.deltaTime);

                }

            } else {

                // manual rotate
                if (Input.GetKeyDown(KeyCode.LeftArrow)) {
                    go.transform.Rotate(new Vector3(0, 1, 0) * bounceSpeed);
                }
                if (Input.GetKeyDown(KeyCode.RightArrow)) {
                    go.transform.Rotate(new Vector3(0, -1, 0) * bounceSpeed);
                }

            }

            //Debug.Log(go.transform.rotation.x);
        }
    }
}