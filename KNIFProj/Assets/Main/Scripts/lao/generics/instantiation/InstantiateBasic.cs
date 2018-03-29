using UnityEngine;
using System.Collections;

namespace LAO.Generic {

    /// <summary>
    /// Instantiating an instance is one thing. It creates an instance into scene.
    /// Using Resource load to load a prefab or texture is different. It loads it into memorr but will not put it into scene.
    /// </summary>
    public class InstantiateBasic : MonoBehaviour {

        /*
        Must set the gameObject and the spawnLocator for this to work
        */
        private GameObject go;
        public Transform spawnLocatorReference;

        // Use this for initialization
        void Start() {
            go = this.gameObject;
            //find spawn point at start
            //t = GameObject.Find("centerSpawn").transform;

            //instantiate dynamically from folder
            //go = (GameObject)Instantiate(Resources.Load("assets/images/prod1"), t.position, Quaternion.identity);

            // instantiate from linking gameobject to go variable in scene
            go = (GameObject)Instantiate(go.gameObject, spawnLocatorReference.position, Quaternion.identity);

            //new gameobject
            //GameObject myGO = new GameObject("GO_Name");

            //adding monobehaviour/component class to gameobjects
            //myGO.AddComponent<SomeComponentClass>();

            //getting component from gameobject
            //ComponentClass compClass = myGO.GetComponent<ComponentClass>();

        }

        // Update is called once per frame
        void Update() {

        }
    }
}