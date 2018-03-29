using UnityEngine;
using System.Collections;

public class DestroyMeBelowGround : MonoBehaviour {

   
	// Update is called once per frame
	void Update () {
	    if(this.gameObject.transform.position.y <= -10) {
            Destroy(this.gameObject);
        }
	}
}
