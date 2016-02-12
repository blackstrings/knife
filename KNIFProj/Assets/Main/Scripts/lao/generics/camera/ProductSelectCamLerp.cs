using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace LAO.Generic {

    /// <summary>
    /// Only useful for an empty scene and there are objects in the scene
    /// </summary>
    public class ProductSelectCamLerp : MonoBehaviour {

        //singleton
        //public static CameraLerp instance;
        public bool slideIn;    // custom hack code, delete it when not using it, works with TimeLineController

        public GameObject go;
        private Transform locator;
        private GameObject locator2;
        public Transform positionLocator;
        public float speed = 1.0f;
        public int screen = 0;
        public float distance = 5f;
        public float verticalBound = 0f;
        public float horizontalBound = 0f;

        GameObject locator_lvl_1;
        GameObject locator_lvl_2;
        GameObject locator_lvl_3;

        GameObject cam_main;
        GameObject cam_top;

        //for instantiation
        //******************
        public GameObject prefabToDuplicate;
        private GameObject container_products;

        void Awake() {
            // allowsyou to call the singleton class from anywhere inside any script in current scene where
            // this script is attach to
            //instance = this;
        }

        public List<GameObject> objList { get; set; }
        private ProductSelectController controller;

        // Use this for initialization
        void Start() {
            //get cameras
            go = this.gameObject;
            //cam_top = GameObject.Find("cam_top").gameObject;


            controller = ProductSelectController.instance;
            //default starting position for camera
            locator2 = new GameObject();
            //starting position
            locator2.transform.Translate(new Vector3(horizontalBound, verticalBound, distance));
        }



        // Update is called once per frame
        void Update() {

            if (controller.isReady) {
                readKeyInputs();

                //lerp camera
                go.transform.position = Vector3.Lerp(go.transform.position, locator2.transform.position, speed * Time.deltaTime);

            }
        }


        int col = 1;
        /**
        * Key inputs 
        */
        private void readKeyInputs() {
            // * move right
            if (Input.GetKeyUp(KeyCode.LeftArrow)) {
                if (screen >= controller.guiProductList.Count - 1) {
                    screen = 0;
                } else {
                    screen += col;  // ++ if you just want to jump by 1
                    Debug.Log(screen);
                }

                // reference screens dynamically
                locator2.transform.position = controller.guiProductList[screen].transform.position;
                locator2.transform.Translate(new Vector3(horizontalBound, verticalBound, distance));
            }

            // * move left
            if (Input.GetKeyUp(KeyCode.RightArrow)) {
                // prevent negative
                if (screen - col <= 0) {
                    screen = 0;
                } else {
                    screen -= col;
                }

                // reference screens dynamically
                locator2.transform.position = controller.guiProductList[screen].transform.position;
                locator2.transform.Translate(new Vector3(horizontalBound, verticalBound, distance));
            }

            // *  move up
            //		if(Input.GetKeyUp(KeyCode.UpArrow)){
            //			if(screen >= objList.Count-1){
            //				screen = 0;
            //			}else{
            //				screen += 1;	// ++ if you just want to jump by 1
            //				Debug.Log(screen);
            //			}
            //			
            //			// reference screens dynamically
            //			locator = objList[screen].gameObject.transform.FindChild("locator").transform;
            //		}




            // * move down
            //		if(Input.GetKeyUp(KeyCode.DownArrow)){
            //			// prevent negative
            //			if(screen - 1 <= 0){
            //				screen = 0;
            //			}else{
            //				screen -= 1;
            //			}
            //			
            //			// reference screens dynamically
            //			locator = objList[screen].gameObject.transform.FindChild("locator").transform;
            //		}

            // * home or zero
            //		if(Input.GetKeyUp(KeyCode.H)){
            //			// prevent negative
            //			screen = 0;
            //			
            //			// reference screens dynamically
            //			locator = objList[screen].gameObject.transform.FindChild("locator").transform;
            //		}

            // * toggle cam top view
            //		if(Input.GetKeyUp(KeyCode.Space)){
            //			//toggle camera to top view
            //			if(cam_top.gameObject.camera.enabled == false){
            //				cam_top.gameObject.camera.enabled = true;
            //			}else{
            //				cam_top.gameObject.camera.enabled = false;
            //			}
            //		}
        }

        public void test() {
            Debug.Log("test");
        }
    }
}