using UnityEngine;

namespace LAO.Generic.Animation {

    [RequireComponent(typeof(Rigidbody))]

    public class Jump : MonoBehaviour {

        public float thrust = 5f;
        public bool canJump = false;

        Rigidbody rb = null;

        void Start() {
            rb = gameObject.GetComponent<Rigidbody>();
        }

        /// <summary>
        /// Only runs once, so it's pretty efficient
        /// </summary>
        /// <param name="col"></param>
        void OnCollisionEnter(Collision col) {
            if (col.gameObject.tag.Equals("ground")) {
                canJump = true;
            }
        }

        void OnCollisionExit(Collision col) {
            if (col.gameObject.tag.Equals("ground")) {
                canJump = false;
            }
        }

        void Update() {
            if (Input.GetKeyDown(KeyCode.Space) && canJump) {
                rb.AddForce(transform.up * thrust);
            }
        }

    }
}