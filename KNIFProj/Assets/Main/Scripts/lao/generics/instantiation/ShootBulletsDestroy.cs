using UnityEngine;

namespace LAO.Generic {

    public class ShootBulletsDestroy : MonoBehaviour {

        // Use this for initialization
        void Start() {
            Destroy(gameObject, 5.0f);
        }
    }
}