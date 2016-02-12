using UnityEngine;
using System.Collections;

namespace LAO.Generic {

    public class RotateByVector3Adv : MonoBehaviour {

        public Transform pivot;

        public bool testUpdate;
        public float x;
        public float y;
        public float z;

        public float axisX;
        public float axisY;
        public float axisZ;

        public AnimationCurve animCurve;

        public float xEnd;
        public float yEnd;
        public float zEnd;

        private Quaternion origRotation;
        private Quaternion endRotation;

        private Vector3 direction = new Vector3();

        /// <summary>
        /// useless method to kill warning
        /// </summary>
        private void test() {
            Debug.Log("useless method " + direction);
        }

        // Use this for initialization
        void Start() {

            if (pivot == null) {
                pivot = this.gameObject.transform;
            }

            origRotation = pivot.rotation;
            endRotation = Quaternion.Euler(xEnd, yEnd, zEnd);

            //StartCoroutine(playAnim());


        }

        void Update() {
            //many ways to set the rotation automatically to specified angle or degree
            //keep in mind Quaternion users float values from 0-1 for defining angles, where 1 = 360
            //to use degree values, you have to use Vector3
            //the xyz rotation you see in the inspector can be controlled using the transform.locatoRotation.eulerAngles
            if (testUpdate) {

                //the main code
                pivot.rotation = Quaternion.Euler(new Vector3(x, y, z));

                //pivot.Rotate(direction,1*speed);
            } else {
                pivot.rotation = Quaternion.Slerp(origRotation, endRotation, .05f);
            }


        }

        IEnumerator playAnim() {

            while (!testUpdate) {
                //third param means 0 is the starting position and 1 is the ending position
                pivot.rotation = Quaternion.Slerp(origRotation, endRotation, Time.deltaTime * .05f);
                yield return null;
            }

        }
        
    }
}