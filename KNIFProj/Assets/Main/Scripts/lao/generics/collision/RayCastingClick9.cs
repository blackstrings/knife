using UnityEngine;
using System.Collections;

namespace LAO.Generic {

    /// <summary>
    /// RaycastingClick will allow you to detect mouse collision clicks
    ///  Do not put this class on multiple individual objects
    ///  instead put it only on one camera or game object only in the scene
    ///  or you will get multple calls for one click
    /// </summary>
    public class RayCastingClick9 : MonoBehaviour {

        public enum CollisionType { CONTINUOUSMOUSEPOSITION, CLICKHITALL, CLICKHITONE };
        private CollisionType collisionType;


        void Start() {
            // Set collision
            // toggle ON/OFF your choice of raycast

            //collisionType = CollisionType.CLICKHITONE;		// hit just one object
            collisionType = CollisionType.CLICKHITALL;          // hit multiple objects overlapping
                                                                //collisionType = CollisionType.MOUSEPOSITION;		// continuous mouse position detection
        }

        void Update() {

            // check which type of collision to detect and the click type
            switch (collisionType) {
                case CollisionType.CLICKHITALL:
                    clickHitAllCollision();
                    break;
                case CollisionType.CONTINUOUSMOUSEPOSITION:
                    continuousMousePositionCollision();
                    break;
                case CollisionType.CLICKHITONE:
                    clickHitOneCollision();
                    break;
                default:
                    // do nothing
                    break;
            }

        }

        // Set collision type
        public void setCollision(CollisionType c) {
            collisionType = c;
        }

        // mouseDown - raycast through all collisions it hits
        private void clickHitAllCollision() {
            //------------------------------------------------------------------------------------
            //----------- This is the code snippet can be extracted into Update function ---------
            if (Input.GetMouseButtonUp(0)) {
                RaycastHit hit;
                if (Physics.Raycast(transform.position, -Vector3.up, out hit)) {
                    float distanceToGround = hit.distance;
                    Debug.Log(hit.collider.gameObject.name + " hit distance: " + distanceToGround);
                }
            }
            //------------------------------------------------------------------------------------
        }

        // continuous raycast collision to where mouse position is
        private void continuousMousePositionCollision() {
            //------------------------------------------------------------------------------------
            //---------- This is the code snippet can be extracted into Update function ----------
            float maxDistance = 100;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, maxDistance))
                print("Hitting something");
            //------------------------------------------------------------------------------------
        }

        // not working yet
        private void clickHitOneCollision() {
            if (Input.GetMouseButtonUp(0)) {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if (GetComponent<Collider>().Raycast(ray, out hit, 100.0F)) {
                    Debug.DrawLine(ray.origin, hit.point);
                }
            }
        }

    }
}