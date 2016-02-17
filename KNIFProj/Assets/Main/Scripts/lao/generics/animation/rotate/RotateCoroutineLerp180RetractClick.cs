using UnityEngine;
using System.Collections;

namespace LAO.Generic {

    /// <summary>
    /// Speed rotation is controlled by the animation curve and time duration. 
    /// Flexible but the downside is the highest degree you can go to is 180 per angle.
    /// this setup can reverse the rotation
    /// </summary>
    public class RotateCoroutineLerp180RetractClick : MonoBehaviour {

        public Transform pivot;
        public float xAngle;
        public float yAngle;
        public float zAngle;
        public float duration;
        public AnimationCurve animCurve;
        public bool toggleDebugMode;

        private bool canClick;
        private bool reverse;
        private Quaternion origRotation;
        private Quaternion newRotation;
        private Quaternion desiredRotation;


        // Use this for initialization
        void Start() {

            //if pivot is not manually assigned at the gui, assign pivot to whatever GO the script is current attached to
            if (pivot == null) {
                pivot = this.gameObject.transform;
            }

            origRotation = pivot.rotation;

            desiredRotation = Quaternion.Euler(xAngle, yAngle, zAngle);
            newRotation = origRotation * desiredRotation; //set the ending angle rotation

            play();

        }

        //so the animation can be played again
        public void play() {
            StartCoroutine(animate());
        }

        IEnumerator animate() {

            //allow tuning and seeing update in realtime when changing xyz values in the editor
            if (toggleDebugMode) {
                desiredRotation = Quaternion.Euler(xAngle, yAngle, zAngle);
                newRotation = origRotation * desiredRotation; //set the ending angle rotation
            }

            float timerCounter = 0.0f;

            while (timerCounter <= duration) {
                if (!reverse) {
                    pivot.rotation = Quaternion.Lerp(origRotation, newRotation, animCurve.Evaluate(timerCounter / duration));
                } else {
                    pivot.rotation = Quaternion.Lerp(newRotation, origRotation, animCurve.Evaluate(timerCounter / duration));
                }

                timerCounter += Time.deltaTime;

                yield return null;
            }

            reverse = !reverse;
            canClick = true;
        }

        //for OnMouseUp to work, the gameObject this script is attached to must have a collider and mesh renderer.
        void OnMouseUp() {
            if (canClick) {
                canClick = false;
                play();

            }
        }
    }
}