using UnityEngine;
using System.Collections;

namespace LAO.Generic.Destroy {

    //upon start, object will self destruct in X seconds.
    /// <summary>
    /// Default is 3 seconds for self destruct.
    /// Must call setDelay to start the countdown.
    /// </summary>
    public class SelfDestructAuto : MonoBehaviour {

        /// <summary>
        /// <para>To time in seonds it takes to trigger.</para>
        /// </summary>
        public float delay = 3f;
        // Use this for initialization
        void Start() {

            //best to call setDelay to start the countdown
            Destroy(this.gameObject, delay);
        }

        public void setDelay(float sec) {
            if (sec <= 0) { //prevent zero values
                delay = 3f;
            }
            Destroy(this.gameObject, delay);
        }
        
    }
}
