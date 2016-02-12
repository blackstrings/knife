using UnityEngine;
using System.Collections;

namespace LAO.Generic.Animation {

    public class RectTransTranslate : MonoBehaviour {

        // Use this for initialization
        void Start() {

        }

        // Update is called once per frame
        void Update() {

        }

        public int x;

        public void move() {
            this.GetComponentInParent<RectTransform>().position = new Vector3(10, 10, 10);
        }
    }
}
