using UnityEngine;
using System.Collections;

/***
to set the angle, there are multiple ways
transform.rotation = Quaternion.Euler(0, 90, 0); // will set the rotation of the object automatically to this degree
go.transform.Rotate(Vector3.up, 1);	//will rotate the object in this direction by 1 unit, if called in a loop, it will animate
angles are Quaternions
quaternion * quaternion = new quaternion
*/
namespace LAO.Generic {

    public class RotateByVector3Basic : MonoBehaviour {

        public Transform pivot;

        public bool testUpdate;
        public float x;
        public float y;
        public float z;
        public float speed = 1f;
        
        // Use this for initialization
        void Start() {

            if (pivot == null) {
                pivot = this.gameObject.transform;
            }

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
            }

        }

    }
}