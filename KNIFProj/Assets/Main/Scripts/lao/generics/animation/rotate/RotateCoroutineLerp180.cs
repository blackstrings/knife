using UnityEngine;
using System.Collections;

namespace LAO.Generic {

    /// <summary>
    /// Speed rotation is controlled by the animation curve and time duration. 
    /// Flexible but the downside is the highest degree you can go to is 180 per angle.
    /// </summary>
    public class RotateCoroutineLerp180 : MonoBehaviour {

        public Transform pivot;
        public float xAngle;
        public float yAngle;
        public float zAngle;
        public float duration;
        public AnimationCurve animCurve;

        private Quaternion origRotation;
        private Quaternion newRotation;
        private Quaternion desiredRotation;

        // Use this for initialization
        void Start() {

            desiredRotation = Quaternion.Euler(xAngle, yAngle, zAngle);

            //if pivot is not manually assigned at the gui, assign it to whatever the script is current attached to
            if (pivot == null) {
                pivot = this.gameObject.transform;
            }
            origRotation = pivot.rotation;
            newRotation = origRotation * desiredRotation; //set the ending angle rotation

            play();

        }

        //so the animation can be played again
        public void play() {
            StartCoroutine(animate());
        }

        IEnumerator animate() {
            float timerCounter = 0.0f;
            while (timerCounter <= duration) {
                pivot.rotation = Quaternion.Lerp(origRotation, newRotation, animCurve.Evaluate(timerCounter / duration));

                timerCounter += Time.deltaTime;

                yield return null;
            }
        }
    }
}