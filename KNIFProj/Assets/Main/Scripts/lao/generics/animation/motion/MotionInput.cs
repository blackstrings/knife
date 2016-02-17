using UnityEngine;

namespace LAO.Generic.Animation {

    public class MotionInput : MonoBehaviour {

        public float speed = 3f;
        // Use this for initialization
        void Start() {
            if (speed == 0f) {
                speed = 3f;
            }
        }

        // Update is called once per frame
        void Update() {
            //get left and right inputs only
            transform.Translate(Input.GetAxis("Horizontal") * speed * Time.deltaTime, 0, 0);
            transform.Translate(0, 0, Input.GetAxis("Vertical") * speed * Time.deltaTime);
            
        }
    }

}
