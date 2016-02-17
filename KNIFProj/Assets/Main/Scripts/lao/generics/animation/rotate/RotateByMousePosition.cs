using UnityEngine;
using System.Collections;

namespace LAO.Generic {

    public class RotateByMousePosition : MonoBehaviour {

        public float RotationSpeed = 3f;

        // Use this for initialization
        void Start() {

        }

        // Update is called once per frame
        void Update() {
            transform.Rotate((Input.GetAxis("Mouse X") * RotationSpeed * Time.deltaTime), (Input.GetAxis("Mouse Y") * RotationSpeed * Time.deltaTime), 0, Space.World);
        }
    }
}
