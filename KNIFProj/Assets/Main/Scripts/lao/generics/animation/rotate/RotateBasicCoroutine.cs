using UnityEngine;
using System.Collections;

namespace LAO.Generic {
    
    /// <summary>
    /// to set the angle, there are multiple ways
    /// transform.rotation = Quaternion.Euler(0, 90, 0); // will set the rotation of the object automatically to this degree
    /// go.transform.Rotate(Vector3.up, 1);	//will rotate the object in this direction by 1 unit, if called in a loop, it will animate
    /// quaternion* quaternion = new quaternion
    /// </summary>
    public class RotateBasicCoroutine : MonoBehaviour {

        public Transform pivot;
        public bool x;
        public bool y;
        public bool z;
        public bool reverse;
        public float speed = 1f;

        private Vector3 direction;
        private bool complete = false;
        private float compareVal = 1f;

        /// <summary>
        /// useless func to kill warning
        /// </summary>
        private void test() {
            Debug.Log(compareVal);
        }

        // Use this for initialization
        void Start() {

            if (pivot == null) {
                pivot = this.gameObject.transform;
            }

            if (x && reverse) {
                compareVal = -1f;
                direction = Vector3.forward;
            } else if (x && !reverse) {
                direction = Vector3.back;
            } else if (y && reverse) {
                compareVal = -1f;
                direction = Vector3.left;
            } else if (y && !reverse) {
                direction = Vector3.right;
            } else if (z && reverse) {
                compareVal = -1f;
                direction = Vector3.down;
            } else if (z && !reverse) {
                direction = Vector3.up;
            }

            play();

        }

        public void play() {
            StartCoroutine(animate());
        }

        IEnumerator animate() {

            //infinite loop until complete is somehow set to true
            while (!complete) {
                pivot.Rotate(direction, 1 * speed);
                yield return null;
            }


        }
    }
}