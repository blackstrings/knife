using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace LAO.Generic {

    /// <summary>
    /// This call will check every X seconds to see whether or not to hide the gameobject
    /// This class needs to be put on a parent gameobject, as it will hide it's child gameobject
    /// so when the child is hidden, this class can still continue to run checks
    /// If the class is assigned to a child, when the child is not active, this class will no longer run checks
    /// </summary>
    public class HideBaseOnSize : MonoBehaviour {

        void Start() {
            if (childGameObject != null) {
                StartCoroutine(adjustSize());
            }
        }

        public GameObject childGameObject;
        public bool isHidden;

        private float timerCounter;
        public float checkEveryXsecond;

        public float minScreenWidth;
        public float minScreenHeight;

        IEnumerator adjustSize() {
            timerCounter = 0f;

            //getting the size of the gameobject may be more trickier, thus we should use the screen size instead
            /*width = this.gameObject.GetComponent<RectTransform>().localScale.x;
            height = this.gameObject.GetComponent<RectTransform>().localScale.y;
            Debug.Log(width + " : " + height);
            */


            //-------------------------------------- code trigger here
            if (Screen.height < minScreenHeight || Screen.width < minScreenWidth) {
                isHidden = true;
                childGameObject.SetActive(false);
            } else {
                if (childGameObject.activeSelf == false) {
                    isHidden = false;
                    childGameObject.SetActive(true);
                }
            }
            //-------------------------------------

            if (checkEveryXsecond < 0.25f) {
                checkEveryXsecond = 1.0f;    //prevent every near zero sec check, default to 1.0f
            }

            //Debug.Log(Screen.height + " : " + Screen.width);

            while (timerCounter <= checkEveryXsecond) {
                timerCounter += Time.deltaTime;
                yield return null;
            }

            StartCoroutine(adjustSize());   //recursive call after every duration reach
        }
    }

}