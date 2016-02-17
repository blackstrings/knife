using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace LAO.Generic {

    /// <summary>
    /// This class really isn't a usuable class unless you have an empty scene setup
    /// </summary>
    public class CameraLerp : MonoBehaviour {

        //singleton
        public static CameraLerp instance;
        public bool slideIn;    // custom hack code, delete it when not using it, works with TimeLineController

        public GameObject go;
        private Transform locator;
        public Transform positionLocator;
        public float speed = 1.0f;
        public int screen = 0;

        GameObject locator_lvl_1;
        GameObject locator_lvl_2;
        GameObject locator_lvl_3;

        GameObject cam_main;
        GameObject cam_top;

        //for instantiation
        //******************
        public GameObject prefabToDuplicate;
        private GameObject container_products;

        // prepare variables to instantiate into a 2D grid layout
        private List<GameObject> objList;
        public int row = 7;
        public int col = 3;
        private int count = 0;  // just counts the douplication, row and col determines the instantiate count
        private int gap = 20;
        //*******************

        private void test() {
            Debug.Log("useless method" + locator_lvl_2 + " : " + locator_lvl_3 + " cam: " + cam_main);
        }

        void Awake() {
            // allowsyou to call the singleton class from anywhere inside any script in current scene where
            // this script is attach to
            instance = this;
        }


        // Use this for initialization
        void Start() {
            //get cameras
            cam_main = GameObject.Find("cam_main").gameObject;
            cam_top = GameObject.Find("cam_top").gameObject;

            //create screens
            objList = new List<GameObject>();
            container_products = new GameObject("levels");  // organize leves into this gameobject
            createScreens();

            locator_lvl_1 = GameObject.Find("lvl1").gameObject.transform.FindChild("locator").gameObject;
            locator_lvl_2 = GameObject.Find("lvl2").gameObject.transform.FindChild("locator").gameObject;
            locator_lvl_3 = GameObject.Find("lvl3").gameObject.transform.FindChild("locator").gameObject;

            //default starting position for camera
            locator = locator_lvl_1.transform;
        }

        // Update is called once per frame
        void Update() {

            readKeyInputs();


            //
            go.transform.position = Vector3.Lerp(go.transform.position, locator.transform.position, speed * Time.deltaTime);

        }

        public void createScreens() {
            int counter = 0;
            GameObject txt3d;
            GameObject insideChild;
            string path;

            for (int i = 0; i < row; i++) {

                for (int n = 0; n < col; n++) {

                    // instantiate
                    GameObject temp = (GameObject)Instantiate(prefabToDuplicate.gameObject, positionLocator.position, Quaternion.identity);

                    // ------------------ Start of Font ----------------
                    // Cannot assign new name because guitext is a prefab which will change all names
                    // in order to create new text and be unique, you must create a 3d text object as
                    // new prefeb outside from instantiated gameobject

                    // title 1
                    path = "assets/3d/shapes/txtScreen";
                    txt3d = (GameObject)Instantiate(Resources.Load(path), temp.transform.position, Quaternion.identity);
                    txt3d.name = "dynamicText";
                    txt3d.transform.parent = temp.transform;
                    txt3d.GetComponentInChildren<TextMesh>().text = "Screen " + counter;

                    insideChild = temp.transform.FindChild("title1").gameObject;
                    txt3d.transform.position = insideChild.transform.position;
                    txt3d.transform.rotation = insideChild.transform.rotation;

                    // title 2
                    path = "assets/3d/shapes/txtScreen";
                    txt3d = (GameObject)Instantiate(Resources.Load(path), temp.transform.position, Quaternion.identity);
                    txt3d.name = "dynamicText2";
                    txt3d.transform.parent = temp.transform;
                    txt3d.GetComponentInChildren<TextMesh>().text = "Screen " + counter;

                    insideChild = temp.transform.FindChild("title2").gameObject;
                    txt3d.transform.position = insideChild.transform.position;
                    txt3d.transform.rotation = insideChild.transform.rotation;
                    txt3d.GetComponent<TextMesh>().characterSize = .3f;

                    //----------------- END of Font -----------------



                    //instantiate dynamically from folder
                    //prefabToDuplicate = (GameObject)Instantiate(Resources.Load("assets/images/prod1"), t.position, Quaternion.identity);

                    // reposition
                    temp.transform.Translate(new Vector3(i * gap, 0, n * gap));

                    // organize the instance into container_products
                    temp.transform.parent = container_products.transform;

                    // rename members
                    count++;
                    temp.name = "lvl" + count;

                    // add new member to list
                    objList.Add(temp.gameObject);



                    // attach scripts to objects
                    //temp.AddComponent("RayCastingClick9");

                    // access script and modify it
                    //temp.GetComponentInChildren<RayCastingClick9>().setCollision(RayCastingClick9.CollisionType.CLICK);

                    counter++;
                }
            }
        }

        /**
        * Key inputs 
        */
        private void readKeyInputs() {
            // * move right
            if (Input.GetKeyUp(KeyCode.RightArrow)) {
                if (screen >= objList.Count - 1) {
                    screen = 0;
                } else {
                    screen += col;  // ++ if you just want to jump by 1
                    Debug.Log(screen);
                }

                // reference screens dynamically
                locator = objList[screen].gameObject.transform.FindChild("locator").transform;
            }
            // *  move up
            if (Input.GetKeyUp(KeyCode.UpArrow)) {
                if (screen >= objList.Count - 1) {
                    screen = 0;
                } else {
                    screen += 1;    // ++ if you just want to jump by 1
                    Debug.Log(screen);
                }

                // reference screens dynamically
                locator = objList[screen].gameObject.transform.FindChild("locator").transform;
            }
            // * move left
            if (Input.GetKeyUp(KeyCode.LeftArrow)) {
                // prevent negative
                if (screen - col <= 0) {
                    screen = 0;
                } else {
                    screen -= col;
                }

                // reference screens dynamically
                locator = objList[screen].gameObject.transform.FindChild("locator").transform;
            }

            // * move down
            if (Input.GetKeyUp(KeyCode.DownArrow)) {
                // prevent negative
                if (screen - 1 <= 0) {
                    screen = 0;
                } else {
                    screen -= 1;
                }

                // reference screens dynamically
                locator = objList[screen].gameObject.transform.FindChild("locator").transform;
            }

            // * home or zero
            if (Input.GetKeyUp(KeyCode.H)) {
                // prevent negative
                screen = 0;

                // reference screens dynamically
                locator = objList[screen].gameObject.transform.FindChild("locator").transform;
            }

            // * toggle cam top view
            if (Input.GetKeyUp(KeyCode.Space)) {
                //toggle camera to top view
                if (cam_top.gameObject.GetComponent<Camera>().enabled == false) {
                    cam_top.gameObject.GetComponent<Camera>().enabled = true;
                } else {
                    cam_top.gameObject.GetComponent<Camera>().enabled = false;
                }
            }
        }

       
    }

  
}