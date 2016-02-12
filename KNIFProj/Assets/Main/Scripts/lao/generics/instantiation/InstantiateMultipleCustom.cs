using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace LAO.Generic {

    public class InstantiateMultipleCustom : MonoBehaviour {

        /*
        Must set inside inspector:
        prefabToDuplicate, positionLocator
        */
        public GameObject go;
        private GameObject thisGo;
        //public GameObject prefabToDuplicate;
        public Transform positionLocator;
        public GameObject container_products;

        // prepare variables to instantiate into a 2D grid layout
        private List<GameObject> objList;
        public int row = 5;
        public int col = 5;
        private int count = 0;
        public int gap = 3;
        public bool activateY;
        public bool inverse;

        // Use this for initialization
        void Start() {
            thisGo = this.gameObject;
            //objList
            objList = new List<GameObject>();

            // prepare & create a container in the UI to hold all products
            // this will allow organizing runtime objects easier in the UI
            //container_products = new GameObject("container_products");

            // parent gameobject under the gameObject world
            //container_products.transform.parent = GameObject.Find ("menu1").transform;
            //container_products.transform.parent = GameObject.Find ("menu1").transform;

            // create sub productSets
            //GameObject productSet = new GameObject("productSet1");

            // put parent under products
            //productSet.transform.parent = container_products.transform;
            //objParent.transform.parent = GameObject.Find("products").transform;

            createProducts();
        }

        public void createProducts() {
            for (int i = 0; i < row; i++) {

                for (int n = 0; n < col; n++) {

                    // instantiate
                    //GameObject temp = (GameObject)Instantiate(prefabToDuplicate.gameObject, positionLocator.position, Quaternion.identity);
                    GameObject temp = (GameObject)Instantiate(go.gameObject, go.transform.position, Quaternion.identity);
                    temp.transform.localScale = go.transform.lossyScale;
                    //instantiate dynamically from folder
                    //prefabToDuplicate = (GameObject)Instantiate(Resources.Load("assets/images/prod1"), t.position, Quaternion.identity);

                    // reposition
                    if (!activateY && !inverse)
                        temp.transform.Translate(new Vector3(i * gap, 0, n * gap));
                    else if (!activateY && inverse)
                        temp.transform.Translate(new Vector3(i * gap, 0, -n * gap));
                    else if (activateY && !inverse)
                        temp.transform.Translate(new Vector3(i * gap, n * gap, 0));
                    else if (activateY && inverse)
                        temp.transform.Translate(new Vector3(i * gap, -n * gap, 0));

                    // organize the instance into container_products
                    temp.transform.parent = thisGo.transform;

                    // rename members
                    count++;
                    temp.name = "item" + count;

                    // add new member to list
                    objList.Add(temp.gameObject);

                    // attach scripts to objects
                    //temp.AddComponent("RayCastingClick9");

                    // access script and modify it
                    //temp.GetComponentInChildren<RayCastingClick9>().setCollision(RayCastingClick9.CollisionType.CLICK);

                }
            }
        }

    }
}