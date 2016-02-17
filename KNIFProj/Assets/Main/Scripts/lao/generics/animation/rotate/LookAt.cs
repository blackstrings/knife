using UnityEngine;

namespace LAO.Generic {

    /// <summary>
    /// Always looks or face toward at target's location
    /// </summary>
    public class LookAtAuto : MonoBehaviour {

        public Transform target;

        // Update is called once per frame
        void Update() {
            Vector3 relativePos = target.position - transform.position;
            transform.rotation = Quaternion.LookRotation(relativePos);
        }
    }
}
