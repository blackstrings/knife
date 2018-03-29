using UnityEngine;
using System.Collections;

public class MovementController : MonoBehaviour {

    GameObject activeGO;

    void Start() {
        setActiveGO();
    }

    //not needed with singleton
    private void setActiveGO() {
        activeGO = TempSingleton.Instance.activeGO = GameObject.Find("Cube_pf");
    }

    // Use this for initialization
    public void move() {
        activeGO.GetComponent<Rigidbody>().AddForce(Vector3.forward * 500f);
    }

    public void reset() {
        TempSingleton.Instance.activeGO.GetComponent<ResetPosition>().init();
    }
}
