using UnityEngine;
using System.Collections;

namespace LAO.Generic {

    public class KeyInput : MonoBehaviour {

        GameObject cam_main;
        public float speed = 3f;

        private bool canLerp = false;

        enum Direction { NORTH, SOUTH, WEST, EAST }
        private int index;

        public GameObject target;
        public GameObject target2;

        private void test() {
            Debug.Log(target);
        }

        // Use this for initialization
        void Start() {
            cam_main = GameObject.Find("cam_main");

            // Finding Angle between two objects
            /*
            target = GameObject.Find("garage1");
            target2 = GameObject.Find("garage2");

            Vector3 targetDir = target.transform.position - target2.transform.position;
            Vector3 forward = target2.transform.forward;
            float angle = Vector3.Angle(targetDir, forward);
            if (angle < 5.0F)
                print(angle + " : close");
            else{
                print (angle);
            }
            */



        }

        // Update is called once per frame
        void Update() {



            if (Input.GetKeyUp(KeyCode.G)) {
                //switch
                canLerp = !canLerp;
            }

            if (Input.GetKeyUp(KeyCode.L)) {
                // look at direction

                switch (index) {

                    case 0:
                        cam_main.transform.LookAt(target.transform);
                        break;

                    case 1:
                        cam_main.transform.LookAt(Vector3.up);
                        break;
                    case 2:
                        cam_main.transform.LookAt(Vector3.down);
                        break;
                    case 3:
                        cam_main.transform.LookAt(Vector3.left);
                        break;

                }

                index++;
                if (index > 3)
                    index = 0;

            }

            if (canLerp) {

                cam_main.transform.position = Vector3.Lerp(cam_main.transform.position, target.transform.position, speed * Time.deltaTime);
            }
        }
    }
}