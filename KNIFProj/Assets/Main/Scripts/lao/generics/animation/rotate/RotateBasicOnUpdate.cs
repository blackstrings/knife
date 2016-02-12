using UnityEngine;

namespace LAO.Generic {

    /// <summary>
    /// to set the angle, there are multiple ways
    /// transform.rotation = Quaternion.Euler(0, 90, 0); // will set the rotation of the object automatically to this degree
    /// go.transform.Rotate(Vector3.up, 1);	//will rotate the object in this direction by 1 unit, if called in a loop, it will animate
    /// quaternion* quaternion = new quaternion
    /// </summary>
    public class RotateBasicOnUpdate : MonoBehaviour {

        public Transform pivot;
        public bool testUpdate;
        public bool x;
        public bool y;
        public bool z;
        public bool reverse;
        public float speed = 1f;

        private Vector3 direction;
        private bool complete;


        // Use this for initialization
        void Start() {

            if (pivot == null) {
                pivot = this.gameObject.transform;
            }

        }

        //with this current setup you have no control over when to stop or start the loop, only the direciton can be controlled at the start of the script.
        ///The rotation starts automactially and goes forever.
        void Update() {
            //pivot.Rotate(Vector3.up,1);
            if (testUpdate) {

                if (x && reverse) {
                    direction = Vector3.forward;
                } else if (x && !reverse) {
                    direction = Vector3.back;
                } else if (y && reverse) {
                    direction = Vector3.left;
                } else if (y && !reverse) {
                    direction = Vector3.right;
                } else if (z && reverse) {
                    direction = Vector3.down;
                } else if (z && !reverse) {
                    direction = Vector3.up;
                }

            }

            //all 6 direction
            //Vector3.up, Vector3.down, Vector3.back, Vector3.forward, Vector3.left, Vector3.right
            pivot.Rotate(direction, 1 * speed);

        }

    }
}