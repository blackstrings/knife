using UnityEngine;
using System.Collections;

namespace LAO.Generic {

    public class TranslateCustom : MonoBehaviour {

        //if you want to reference
        //public GameObject go;

        //setup value init in inspector
        public bool canSimulate = false;
        public bool applyMaxDistance = false;
        public float MAXDISTANCE = 1f;
        public float speed = 1;
        public bool x;
        public bool y;
        public bool z;
        public bool reverse;

        // the animation curve will not be useful in this setup, as you need to provide start position A and end point B
        // hint: if you are not using Math.lerp then don't use the antimation curve
        //public AnimationCurve curve;	

        Vector3 origPos;
        float distanceTraveled = 0f;

        // Use this for initialization
        void Start() {
            if (applyMaxDistance && canSimulate) {
                origPos = this.gameObject.transform.position;
                StartCoroutine(move());
            }
        }

        //basic move but not as effiecient as start coroutine
        void Update() {
            if (!applyMaxDistance && canSimulate) {
                //go upward
                this.gameObject.transform.Translate(new Vector3(0, speed * Time.deltaTime, 0));
            }
        }

        // coroutine method -- to call this method, you must use StartCouroutine();
        IEnumerator move() {
            //setup
            float xVal = x ? 1 : 0;
            float yVal = y ? 1 : 0;
            float zVal = z ? 1 : 0;
            float reverseVal = reverse ? -1 : 1;
            float actualSpeed;

            //loop
            while (distanceTraveled < MAXDISTANCE) {
                actualSpeed = Time.deltaTime * speed;
                this.gameObject.transform.Translate(
                    new Vector3(actualSpeed * xVal * reverseVal,
                                    actualSpeed * yVal * reverseVal,
                                actualSpeed * zVal * reverseVal
                    )
                );

                Vector3 currPos = this.gameObject.transform.position;
                distanceTraveled = Vector3.Distance(currPos, origPos);
                yield return null;  //have to yield here with coroutine
            }
        }
    }
}