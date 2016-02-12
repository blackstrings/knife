using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace LAO.Generic {

    public class InstantiateMultiple : MonoBehaviour {

        /*
        Must set inside inspector:
        prefabToDuplicate, positionLocator
        */
        public GameObject prefabToDuplicate;
        public Transform positionLocator;
        private GameObject container_products;

        // prepare variables to instantiate into a 2D grid layout
        private List<GameObject> objList;
        private int row = 5;
        private int col = 5;
        private int count = 0;
        private int gap = 3;

        // Use this for initialization
        void Start() {

            //objList
            objList = new List<GameObject>();

            // prepare & create a container in the UI to hold all products
            // this will allow organizing runtime objects easier in the UI
            container_products = new GameObject("container_products");
            // parent gameobject under the gameObject world
            container_products.transform.parent = GameObject.Find("World").transform;

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
                    GameObject temp = (GameObject)Instantiate(prefabToDuplicate.gameObject, positionLocator.position, Quaternion.identity);

                    //instantiate dynamically from folder
                    //prefabToDuplicate = (GameObject)Instantiate(Resources.Load("assets/images/prod1"), t.position, Quaternion.identity);

                    // reposition
                    temp.transform.Translate(new Vector3(i * gap, 0, n * gap));

                    // organize the instance into container_products
                    temp.transform.parent = container_products.transform;

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