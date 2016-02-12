using UnityEngine;
using System.Collections;

/// <summary>
/// Every so seconds set by the duration, the object will jump and twirl with the force applied.
/// </summary>
namespace LAO.Generic.Animation {

    public class Puffer : MonoBehaviour {

        private float duration = 3f;
        private GameObject go;

        void Awake() {
            go = this.gameObject;
        }


        public void action() {
            StartCoroutine(animate());
        }

        IEnumerator animate() {

            float timerCounter = 0.0f;

            while (timerCounter <= duration ) {

                timerCounter += Time.deltaTime;
                yield return null;

            }

            //done animating
            float randForce = Random.Range(100f, 600f);
            int randNum = Random.Range(0, 3);
            Vector3 tempVec;
            switch(randNum){
                case 0:
                    tempVec = new Vector3(randForce,0,0);
                    break;
                case 1:
                    tempVec = new Vector3(0, randForce,0);
                    break;
                case 2:
                    tempVec = new Vector3(0, 0,randForce);
                    break;
                default:
                    tempVec = new Vector3(randForce, 0, 0);
                    break;
            }

            go.GetComponent<Rigidbody>().AddForce(tempVec);
            go.GetComponent<Rigidbody>().AddTorque(new Vector3(150, 150, 150));
        }

    }
}