using UnityEngine;
using System.Collections;

namespace LAO.Generic {

    /// <summary>
    /// Raycast testing
    /// </summary>
    public class RayCast9 : MonoBehaviour {

        // Use this for initialization
        private GameObject go;
        
        // Update is called once per frame
        void Update() {
            
            //Menu Click
            //----------- This is the code snippet can be extracted into Update function ---------
            if (Input.GetMouseButtonUp(0)) {
                RaycastHit hit;
                if (Physics.Raycast(transform.position, -Vector3.up, out hit)) {
                    //				if(hit.collider.gameObject.name == go.gameObject.name){
                    Debug.Log(hit.collider.gameObject.name);
                    //				}
                }
            }
            //------------------------------------------------------------------------------------

        }
    }
}