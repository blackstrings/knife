using UnityEngine;
using System.Collections;
using System.Collections.Generic;


namespace LAO.Generic {

    /// <summary>
    /// Simple mouse down on some object. May or may not be useful
    /// </summary>
    public class ProductSelectController : MonoBehaviour {

        //singleton
        public static ProductSelectController instance;

        public List<GameObject> objList { get; set; }

        //
        public ProductDTO productDTO { get; set; }
        public GameObject platform;
        public List<GameObject> guiProductList { get; set; }    //dont' use arrayList as List in c# is superrior to the arrayList now

        public bool isReady { get; set; }

        void Awake() {
            // allowsyou to call the singleton class from anywhere inside any script in current scene where
            // this script is attach to
            instance = this;
        }

        void Start() {
            platform = GameObject.Find("Platform_GO");  // test object to put products on
            objList = new List<GameObject>();


        }

        /// <summary>
        /// Display the selected product onto the object
        /// </summary>
        /// <param name="objPath">Object path.</param>
        public void displaySelectedProduct(ProductDTO selectedProduct) {

            //instantiate vars
            int amountToDuplicate = 7;
            int count = 0;
            float gap = 1f;
            float slope = .2f;

            int loop = 3;

            //destroy pre-existing obj
            deleteProducts();

            //create new obj
            for (int k = 1; k < loop; k++) {

                for (int i = 0; i < amountToDuplicate; i++) {

                    string path = selectedProduct.GetComponent<ProductDTO>().namePath;

                    //string num = k.ToString();

                    string locStr = "loc" + k.ToString();

                    Transform locObj = platform.transform.FindChild(locStr);
                    //Transform loc2 = platform.transform.FindChild("loc2");

                    GameObject temp = (GameObject)Instantiate(Resources.Load(path), locObj.position, locObj.rotation);

                    //relocate obj
                    temp.transform.Translate(new Vector3(i * gap, slope * i, 0));

                    // rename members
                    count++;
                    temp.name = "item" + count;

                    // organize the instance into container_products
                    temp.transform.parent = platform.transform;

                    // add new member to list
                    objList.Add(temp.gameObject);
                }
            }
            Debug.Log(objList.Count);

        }

        private void deleteProducts() {
            //destroy all objects in the list before you put new ones in
            if (objList != null) {
                foreach (GameObject go in objList) {
                    Destroy(go);
                }
                objList = new List<GameObject>();   // empty the list
            }
        }
        
    }
}