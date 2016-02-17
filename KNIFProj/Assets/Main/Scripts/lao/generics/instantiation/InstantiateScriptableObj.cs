using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace LAO.Generic {

    /// <summary>
    /// Scriptable objects are so that unity can serialize the object properly
    /// instead of extending a class from nothing
    /// if you don't need serialization for the class, you don't need to extnend ScriptableObject
    /// </summary>
    public class InstantiateScriptableObj : ScriptableObject {

        public GameObject go;
        public List<GameObject> gos;
        public int num;

        //To instantiate this scriptable object you need to use
        //ClassName myScritableObj = ScriptableObject.createInstance<ClassName>();

        //when you create an instance using 
        //ClassName myObj = ScriptableObject.createInstance<ClassName>();

        //after creation you may want to run this init to act like a default constructor
        //you shouldn't though require a constructor for scriptable objects due to its nature
        public void init(int var1, string var2) {

        }

    }
}