using UnityEngine;
using System.Collections;
using LAO.Generic.Destroy;

namespace LAO.Generic.Instantiation {

    /// <summary>
    /// Spawns target prefabs to random location
    /// Put script on a plane gameObject.
    /// Area of spawn is how large you expand the x and z values of the mesh.
    /// Make sure to populate target_pf and spawnArea_go in the editor.
    /// Do not make BasicSpawn customize whatever GO it is spawning.
    /// The GO prefabs should take care of customizations not this class.
    /// </summary>
    public class SpawnBasicAutoTimer : MonoBehaviour {

        public GameObject target_pf;

        // Use this for initialization
        void Start() {

            //action();
            StartCoroutine(timerSpawn());
        }

        /// <summary>
        /// Delay time in sec interval per spawn
        /// </summary>
        public float delay = 2f;
        IEnumerator timerSpawn() {
            float timerCounter = 0;

            //delay
            while(timerCounter <= delay) {
                
                timerCounter += Time.deltaTime;
                yield return null;
            }

            //when timer is up, call this
            action();

            //repeat
            StartCoroutine(timerSpawn());
        }

        public void action() {
            Renderer rend = gameObject.GetComponent<Renderer>();
            float x = rend.bounds.size.x;
            float z = rend.bounds.size.z;

            //we subtract half of the max to fix the offset
            x = Random.Range(0, x) - (x/2);
            z = Random.Range(0, z) - (z/2);

            GameObject tmpGo = (GameObject)Instantiate(target_pf, this.gameObject.transform.position, Quaternion.identity);

            tmpGo.transform.Translate(x, 0, z);
        }
        
    }
}