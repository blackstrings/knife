using UnityEngine;
using System.Collections;

namespace LAO.Generic {

    /// <summary>
    /// Monobehviour class are component, not objects, so you can't use the new keyword to create them.
    /// </summary>
    public class InstantiateMonoClassToGameObject : MonoBehaviour {

        public GameObject go;

        // Use this for initialization
        void Start() {

        }

        void instantiateByReference() {

            //create a copy of the current go
            GameObject instanceThroughRef = GameObject.Instantiate(go) as GameObject;
            Debug.Log(instanceThroughRef + " created");

        }

        void instantiateNewClassToEmptyGameObject() {
            GameObject gameObj = new GameObject("NewGameObj");

            //use addcomponent to simulate "new" object
            //pretty much adding a component to gameobject creates an instance
            Bar bar = gameObj.AddComponent<Bar>();
            bar.name = "Bar obj";
        }

        class Bar : MonoBehaviour {
            public Bar() { }
            public int age { get; set; }
        }

        /* details of how to crate monobehviour classes in alternative ways, you can't use New keyword
        http://answers.unity3d.com/questions/198260/alternative-new-monobehaviour.html

        CMyMonoBehaviour bla = myGameObject.AddComponent<CMyMonoBehaviour>();


        // or
        CMyMonoBehaviour bla = (CMyMonoBehaviour)myGameObject.AddComponent(typeof(CMyMonoBehaviour));


        // or
        GameObject myGameObject = new GameObject("name",typeof(CMyMonoBehaviour));
        CMyMonoBehaviour bla = myGameObject.GetComponent<CMyMonoBehaviour>();


        // or (if you're not interested in the gameObject instance)
        CMyMonoBehaviour bla = (new GameObject("name")).AddComponent<CMyMonoBehaviour>();
        */


    }
}
 