using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace LAO.Generic {

    /// <summary>
    /// Desotroying Gameobjects
    /// </summary>
    public class DestroyObjectBasic : MonoBehaviour {

        // Use this for initialization
        void Start() {

        }

        public List<GameObject> objList;

        public void deleteObjects() {

            //destroy all objects in the list before you put new ones in
            if (objList != null) {

                foreach (GameObject gameObject in objList) {
                    Destroy(gameObject);
                }

                objList = new List<GameObject>();   //empty the list

            }
        }
    }
}
