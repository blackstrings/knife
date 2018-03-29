using UnityEngine;
using System.Collections;

public class ResetPosition : MonoBehaviour {

    Vector3 origPos;
    Quaternion origRot;

    GameObject go;
    Rigidbody rb;

    void Start() {
        //store all default starting positions and rotation
        go = this.gameObject;
        rb = go.GetComponent<Rigidbody>();
        origPos = go.transform.position;
        origRot = go.transform.rotation;
        Debug.Log(this.gameObject.transform.position);
    }

    // Update is called once per frame
    void Update () {
	    if(go.transform.position.y <= -10) {

            init();
            
        }
	}

    public void init() {
        //reset velocity on transitions and rotations
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;

        //one way to reset rotation
        //go.transform.rotation = Quaternion.Euler(new Vector3(0,0,0));
        go.transform.rotation = Quaternion.identity;
        go.transform.position = origPos;

        Debug.Log("Score: " + TempSingleton.Instance.score);
    }
}
