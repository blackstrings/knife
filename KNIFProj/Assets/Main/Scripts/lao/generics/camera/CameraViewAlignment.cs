using UnityEngine;
using System.Collections;

namespace LAO.Generic {

    /// <summary>
    /// Allows camera to do half or full screen depending on set margin
    /// </summary>
    public class CameraViewAlignment : MonoBehaviour {

        //ref the cmaera gameobject
        public GameObject cam;

        //margin which camera will account for
        public float leftMargin;
        

        // Update is called once per frame
        public void fullScreen() {
            cam.GetComponent<Camera>().pixelRect = new Rect(1f, 1f, Screen.width, Screen.height);
        }

        //custom screen size, find the gap you want to stick the camera to
        //use an update to call customScreen or fullScreen to adjust camera view
        public void customScreen() {
            cam.GetComponent<Camera>().pixelRect = new Rect(Screen.width - (Screen.width - leftMargin), 1f, Screen.width, Screen.height);
        }
    }
}
