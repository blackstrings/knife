using UnityEngine;
using System.Collections;

namespace Lao.Generics.AI {
    /// <summary>
    /// The object will auto close in on the target location
    /// </summary>
    public class AnimateToLocation : MonoBehaviour {

        public Transform targetLocation;

        public bool canAnimate = true;
        // Use this for initialization
        void Start() {
            if (!targetLocation) {

                //attempt to get playerLocation
                targetLocation = GameObject.FindGameObjectWithTag("Player").transform;

                //if still can't find a transform target
                if (!targetLocation) {
                    canAnimate = false;
                }
            }
            StartCoroutine(action());
        }

        IEnumerator action() {
            while (canAnimate) {
                this.gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, targetLocation.position, .5f * Time.deltaTime);
                yield return null;
            }

        }
    }
}