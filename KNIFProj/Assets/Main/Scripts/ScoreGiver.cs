using UnityEngine;
using System.Collections;

public class ScoreGiver : MonoBehaviour {

    float timerCounter = 0f;
    float duration = 2f;
    bool isLanded = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    
    void OnCollisionEnter(Collision col) {
        
        if (col.gameObject.tag == "Player") {
            //Debug.Log("hit");

            isLanded = true;
           StartCoroutine(prepareToGiveScore());
        }
        
    }
    

    void OnCollisionStay(Collision col) {
        /*
        if (isLanded) {
            timerCounter += Time.deltaTime;
        }

        if (timerCounter > duration && isLanded) {
            TempSingleton.Instance.score++;
            Debug.Log("point added");
            isLanded = false;
            timerCounter = 0f;
        }

        Debug.Log(timerCounter + " : score : " + TempSingleton.Instance.score);
        */

    }
    
    void OnCollisionExit(Collision col) {
        if (col.gameObject.tag == "Player") {
            isLanded = false;
           // Debug.Log("exit");
        }
    }

    IEnumerator prepareToGiveScore() {
        timerCounter = 0f;
        while (timerCounter <= duration && isLanded) {
            timerCounter += Time.deltaTime;

            yield return null;
        }

        isLanded = false;
        if (timerCounter >= duration) {
            TempSingleton.Instance.score++;
            TempSingleton.Instance.updateScoreDisplay();

            Color newColor = new Color(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f));
            this.gameObject.GetComponent<Renderer>().material.SetColor("_Color", newColor);

            TempSingleton.Instance.resetPlayer();

           // Debug.Log("point added");
        }
        //Debug.Log("exiting loop");
        
    }
}
