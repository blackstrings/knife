using UnityEngine;

namespace LAO.Generic {
    public class MovementBasicDirect : MonoBehaviour {

        // Use this for initialization

        private bool isSouth = false;
        private bool isNorth = false;
        private bool isEast = false;
        private bool isWest = false;

        public float speed = 1f;

        // Update is called once per frame
        void Update() {

            //west
            if (Input.GetKey(KeyCode.LeftArrow)) {
                isWest = true;
            } else if (!Input.GetKeyDown(KeyCode.LeftArrow)) {
                isWest = false;
            }

            //east
            if (Input.GetKey(KeyCode.RightArrow)) {
                isEast = true;
            } else if (!Input.GetKeyDown(KeyCode.RightArrow)) {
                isEast = false;
            }

            //North
            if (Input.GetKey(KeyCode.UpArrow)) {
                isNorth = true;
            } else if (!Input.GetKeyDown(KeyCode.UpArrow)) {
                isNorth = false;
            }

            //south
            if (Input.GetKey(KeyCode.DownArrow)) {
                isSouth = true;
            } else if (!Input.GetKeyDown(KeyCode.DownArrow)) {
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
