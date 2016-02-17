using UnityEngine;

namespace LAO.Generic.Animation {

    [RequireComponent(typeof(Jump))]
    public class MovementBasicWithJump : MonoBehaviour {

        // Use this for initialization

        private bool isSouth = false;
        private bool isNorth = false;
        private bool isEast = false;
        private bool isWest = false;

        public float speed = 1f;

        public Jump jump;

        void Start() {
            jump = GetComponent<Jump>();
        }

        // Update is called once per frame
        void Update() {

            if (jump.canJump) {
                //west
                if (Input.GetKey(KeyCode.LeftArrow)) {
                    isWest = true;
                } else if (!Input.GetKey(KeyCode.LeftArrow)) {
                    isWest = false;
                }

                //east
                if (Input.GetKey(KeyCode.RightArrow)) {
                    isEast = true;
                } else if (!Input.GetKey(KeyCode.RightArrow)) {
                    isEast = false;
                }

                //North
                if (Input.GetKey(KeyCode.UpArrow)) {
                    isNorth = true;
                } else if (!Input.GetKey(KeyCode.UpArrow)) {
                    isNorth = false;
                }

                //south
                if (Input.GetKey(KeyCode.DownArrow)) {
                    isSouth = true;
                } else if (!Input.GetKey(KeyCode.DownArrow)) {
                    isSouth = false;
                }


                if (isWest) {
                    gameObject.transform.Translate(Vector3.left * speed * Time.deltaTime);
                }
                if (isEast) {
                    gameObject.transform.Translate(Vector3.right * speed * Time.deltaTime);
                }
                if (isNorth) {
                    gameObject.transform.Translate(Vector3.forward * speed * Time.deltaTime);
                }
                if (isSouth) {
                    gameObject.transform.Translate(Vector3.back * speed * Time.deltaTime);
                }

            }

        }
    }
}