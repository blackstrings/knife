using UnityEngine;
using System.Collections;

namespace LAO.Generic {

    public class ShootBullets : MonoBehaviour {

        //ref
        public GameObject bulletPrefab;
        public Transform barrelEnd;

        // Update is called once per frame
        void Update() {
            if (Input.GetKeyDown(KeyCode.Space)) {
                GameObject go = (GameObject)Instantiate(bulletPrefab, barrelEnd.position, barrelEnd.rotation);
                go.AddComponent<Rigidbody>();
                go.transform.parent = gameObject.transform.parent;
                go.GetComponent<Rigidbody>().AddForce(barrelEnd.forward * 400);


            }
        }
    }

}