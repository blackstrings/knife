using UnityEngine;
using System.Collections;

using System.Collections.Generic;	// to use list

// To rotate a list of objects around a center point

namespace LAO.Generic {

    public class RotateAroundCircle : MonoBehaviour {

        public GameObject go;
        public GameObject cam;
        private GameObject tempGo;
        public Transform spawnPos;

        public Transform lookAtMe;

        public List<GameObject> objList;    // container for child

        public float totalProducts = 10;
        public float speed = 10;
        //Quaternion rotatePos;

        //int totalProducts = 20;
        //Vector3 centrePos = new Vector3(0,0,32);

        void Start() {

            //speed = totalProducts * .04f;	// speed ratio

            //Instantiate(go, spawnPos, Quaternion.identity);

            objList = new List<GameObject>();   // prepare list

            // instantiate copies test
            /*
            for(int i=0; i<5; i++){
                go = (GameObject)Instantiate(Resources.Load("assets/shapes/Cube"), spawnPos.transform.position, Quaternion.identity);
                go.transform.Translate(i*30,0,0);
                objList.Add(go.gameObject);
            }
            */


            /*
            for (int y = 0; y < 2; y++) {
                for (int x = 0; x < 2; x++) {
                    GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    cube.AddComponent<Rigidbody>();
                    cube.transform.position = new Vector3(x, y, 0);
                }
            }
            */

            // load number of items
            //float totalProducts = 15;

            // automatically set radius according to the number of products
            double radiusX = (double)totalProducts;
            double radiusY = (double)totalProducts;

            // position camera according to radius size
            double camDist = -(radiusX + 10.0);
            cam.transform.Translate(0, 0, (float)camDist);

            for (int pointNum = 0; pointNum < totalProducts; pointNum++) {

                // "i" now represents the progress around the circle from 0-1
                // we multiply by 1.0 to ensure we get a fraction as a result.
                float i = (float)(pointNum * 1.0) / totalProducts;

                // get the angle for this step (in radians, not degrees)
                float angle = (float)(i * Mathf.PI * 2.0);

                // the X & Y position for this angle are calculated using Sin & Cos
                float x = (float)(Mathf.Sin(angle) * radiusX); // radiusX;
                float y = (float)(Mathf.Cos(angle) * radiusY); //radiusY;

                // change x,y,z around for vertical positions
                Vector3 pos = new Vector3(x, 0, y) + spawnPos.transform.position;

                // no need to assign the instance to a variable unless you're using it afterwards:
                tempGo = (GameObject)Instantiate(Resources.Load("assets/3d/shapes/Cube"), pos, Quaternion.identity);

                // organize the child objects into the parent Gameobject
                tempGo.transform.parent = go.transform;

                // add child to list
                objList.Add(tempGo.gameObject);

            }

        }

        // Update is called once per frame
        void Update() {
            /*
            if (rotateR){
                go.transform.Rotate(new Vector3 (0, 50, 0) * Time.deltaTime);
            }else{
                go.transform.Rotate(new Vector3 (0, -50, 0) * Time.deltaTime);
            }

            if (go.transform.rotation.y >= .5){
                rotateR = false;
            }
            if(go.transform.rotation.y <= -.5){
                rotateR = true;
            }
            */

            // WORKING
            /*
            go.transform.Rotate(new Vector3 (0, 50, 0) * Time.deltaTime);

            foreach (GameObject g in objList){
                    g.transform.Rotate(new Vector3 (0, 25, 0) * Time.deltaTime);
            }
            //Debug.Log(go.transform.rotation.x);
            */

            foreach (GameObject g in objList) {
                // rotate around axis
                g.transform.RotateAround(Vector3.zero, Vector3.up, speed * Time.deltaTime);

                //g.transform.rotation = g.transform.rotation * Quaternion.Euler(0,0,90);

                // always face the lookAtMe object
                //g.transform.LookAt(lookAtMe.transform);
                g.transform.LookAt(Vector3.forward);
            }
        }

    }
}