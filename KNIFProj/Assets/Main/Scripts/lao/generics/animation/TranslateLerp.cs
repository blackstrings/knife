using UnityEngine;
using System.Collections;

namespace LAO.Generic {

    public class TranslateLerp : MonoBehaviour {

        //public var
        public bool canSimulate = false;
        public AnimationCurve animCurve;
        public float time;
        public Transform locatorA;
        public Transform locatorB;
        public bool isAnimate;
		private bool goForward;

		public bool autoReverse = false;
        
        // Use this for initialization
        void Start() {
            if (canSimulate) {
                if (locatorA != null) {
                    this.gameObject.transform.position = locatorA.position; //force start here
                    StartCoroutine(animate(time));
                }
            }
        }

        IEnumerator animate(float time) {
            float timer = 0.0f;

			if(goForward){
	            while (timer <= time) {
	                this.gameObject.transform.position = Vector3.Lerp(locatorA.position, locatorB.position, animCurve.Evaluate(timer / time));
	                timer += Time.deltaTime;
	                yield return null;
	            }
			}else{
				while (timer <= time) {
					this.gameObject.transform.position = Vector3.Lerp(locatorB.position, locatorA.position, animCurve.Evaluate(timer / time));
					timer += Time.deltaTime;
					yield return null;
				}
			}

			if(autoReverse){
				goForward = !goForward;
				StartCoroutine(animate(time));
			}
            //anything below here will get hit once, once the animation time completes
            //Debug.Log("Animation Complete");
        }
    }
}