using UnityEngine;
using System.Collections;

namespace LAO.Generic.Animation {

    /// <summary>
    /// Moves object across in a straight line like a bullet.
    /// Make sure to set the tag type of what it should hit.
    /// If the bullet needs to move really fast, use another script that detects if the object
    /// will hit through a ray cast.
    /// </summary>
    [RequireComponent(typeof(Rigidbody))]
    public class Bullet : MonoBehaviour {

        public float speed = 0f;
        public Rigidbody rb;
        public string tagType = "";

        // Use this for initialization
        void Start() {
            if(speed <= 0) {
                speed = 400;
            }

            //attempt to find rigidbody
            if(rb == null) {
                rb = this.gameObject.GetComponent<Rigidbody>();
            }

           //to project forward and its current rotation
           //use tranform forward,right,left,up instead of vector.forward
           //vector forward is refering to world space, so it will always go to the same direction
           rb.AddForce(gameObject.transform.forward * speed);

           Destroy(gameObject, 3f);
        }

        void OnCollisionEnter(Collision col) {
            if (col.gameObject.tag.Equals(tagType)) {
                Destroy(col.gameObject);
                Destroy(gameObject);
            }
        }

        // Update is called once per frame
        /*
        void Update() {
           //rb.AddForce(new Vector3();
        }
        */
    }
}