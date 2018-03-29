using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using LAO.Generic;

public class TempSingleton : Singleton<TempSingleton> {

    public GameObject activeGO { get; set; }

    public int score { get; set; }

    private GameObject scoreDisplay;

    void Start() {
        scoreDisplay = GameObject.Find("txtScore");
    }

	public GameObject getActiveGO() {
        if (activeGO) {
            return activeGO;
        }
        return null;
    }

    public void resetPlayer() {
        if (activeGO) {
            activeGO.GetComponent<ResetPosition>().init();
        }
    }

    public void updateScoreDisplay() {
        scoreDisplay.GetComponent<Text>().text = "Score: " + score;
    }

}
