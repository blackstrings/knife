using UnityEngine;
using System.Collections;

public class ScoreGiver : MonoBehaviour {

    float timerCounter = 0f;
    float duration = 1000;
    bool isLanded = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    
    void OnCollisionEnter(Collision col) {
        /*
        if (col.gameObject.tag == "Player") {
            Debug.Log("hit");

            isLanded = true;
            StartCoroutine(prepareToGiveScore());
        }
        */
    }
    

    void OnCollisionStay(Collision col) {
        //timerCounter +
    }

    /*
    void OnCollisionExit(Collision col) {
        if (col.gameObject.tag == "Player") {
            isLanded = false;
            Debug.Log("exit");
        }
    }
    */

    IEnumerator prepareToGiveScore() {
        timerCounter = 0f;
        while (timerCounter <= duration && isLanded) {
            timerCounter += Time.deltaTime;

            yield return null;
        }

        isLanded = false;
        if (timerCounter >= duration) {
            TempSingleton.Instance.score++;
            Debug.Log("point added");
        }
        Debug.Log("exiting loop");
        
    }
}
