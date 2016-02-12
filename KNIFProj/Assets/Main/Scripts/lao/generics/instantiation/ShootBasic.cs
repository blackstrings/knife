using UnityEngine;
using System.Collections;
using System;
using LAO.Generic.Animation;

namespace LAO.Generic.Instantiation {

    /// <summary>
    /// A very basic shoot button.
    /// Attach it to a parent go.
    ///  Pareent should have a child that has a empty bulletSpawnLocator_go for the bullet to spawn.
    /// Also map the bullet prefab.
    /// </summary>
    public class ShootBasic : MonoBehaviour {

        public GameObject bullet_pf;
        public GameObject bulletSpawnLocator_go;  //a location for the bullet to spawn at

        // Use this for initialization
        void Start() {

            //attemp to load default bullet prefab if null
            if (!bullet_pf) {
                bullet_pf = (GameObject)Resources.Load("prefabs/bulletTest_pf");
            }

        }

        //gui or controller should call this
        public void action() {
            
            GameObject tempBullet_pf = (GameObject)Instantiate(bullet_pf);
            tempBullet_pf.AddComponent<Bullet>().tagType = "enemy";

            //set pos and rot same as locator
            tempBullet_pf.transform.position = bulletSpawnLocator_go.transform.position;
            tempBullet_pf.transform.rotation = bulletSpawnLocator_go.transform.rotation;
            


        }
    }
}