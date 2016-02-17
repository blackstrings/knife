using UnityEngine;

namespace LAO.Generic {
    
    /// <summary>
    /// Put this on a GUI controller and hook up the player by making sure the player's tag is under "Player"
    /// </summary>
    public class MovementBasicInDirect : MonoBehaviour {

        GameObject player;


        private bool isSouth = false;
        private bool isNorth = false;
        private bool isEast = false;
        private bool isWest = false;

        public float speed = 1f;

        public void goWest() { isWest = true; }
        public void goNorth() { isNorth = true; }
        public void goEast() { isEast = true; }
        public void goSouth() { isSouth = true; }

        public void stopWest() { isWest = false; }
        public void stopNorth() { isNorth = false; }
        public void stopEast() { isEast = false; }
        public void stopSouth() { isSouth = false; }

        void Awake() {
            //hook up player
            if(player == null) {
                player = GameObject.FindGameObjectWithTag("Player");
            }
        }

        // Update is called once per frame
        void Update() {

            if (isWest) {
                player.transform.Translate(Vector3.left * speed * Time.deltaTime);
            }
            if (isEast) {
                player.transform.Translate(Vector3.right * speed * Time.deltaTime);
            }
            if (isNorth) {
                player.transform.Translate(Vector3.forward * speed * Time.deltaTime);
            }
            if (isSouth) {
                player.transform.Translate(Vector3.back * speed * Time.deltaTime);
            }


        }
    }
}
