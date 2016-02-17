using UnityEngine;

namespace LAO.Generic {

    public class RotateCustom : MonoBehaviour {

        public bool canSimulate = false;

        // Use this for initialization
        void Start() {
        }

        // Update is called once per frame
        void Update() {
            if (canSimulate)
                this.gameObject.transform.Rotate(Vector3.up, 1);
        }

    }
}