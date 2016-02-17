using UnityEngine;
using System.Collections;
using System.Text;

namespace LAO.Generic {
    public static class MyUnityUtils {

        /// <summary>
        /// returns the rotation needed in order for fromGo to be looking at toGo
        /// </summary>
        /// <param name="fromGo"></param>
        /// <param name="toGo"></param>
        /// <returns></returns>
        public static Quaternion getRotationNeeded(GameObject fromGo, GameObject toGo) {
            return Quaternion.LookRotation(fromGo.transform.position, toGo.transform.position);   //instant lookAt

        }

        /// <summary>
        /// This will only turn the object a little per frame. An update should call this to effectly see the animation.
        /// </summary>
        /// <param name="gameObject"></param>
        /// <param name="goToLookAt"></param>
        public static void slowlyLookAtGO(GameObject gameObject, GameObject goToLookAt) {
            //you'll want to refactor this into your class your are calling from for better performance
            //because you only need to get the rotationNeeded called once
            Quaternion rotationNeeded = getRotationNeeded(gameObject, goToLookAt);

            gameObject.transform.rotation = Quaternion.Slerp(gameObject.transform.rotation, rotationNeeded, Time.deltaTime);
        }

        /// <summary>
        /// Slowly look at go method 2
        /// </summary>
        /// <param name="go"></param>
        /// <param name="goToRotateTo"></param>
        public static void rotateTowardsGO(GameObject go, GameObject goToRotateTo) {
            float speed = 2f;
            go.transform.rotation = Quaternion.RotateTowards(go.transform.rotation, goToRotateTo.transform.rotation, Time.deltaTime * speed);
        }

        /// <summary>
        /// Face the camera to look at the GO instantly
        /// </summary>
        /// <param name="go_camera"></param>
        /// <param name="goTarget"></param>
        public static void cameraLookAtGoInstantly(GameObject go_camera, GameObject goTarget) {
            go_camera.GetComponent<Camera>().transform.LookAt(goTarget.transform);   //instant lookAt
        }

        public static void readGameObjectMeshVertices(GameObject tempGO) {
            MeshFilter mf = tempGO.GetComponent<MeshFilter>();
            if (mf != null) {
                Vector3[] verts = mf.mesh.vertices;
                StringBuilder sb = new StringBuilder();
                foreach (Vector3 vert in verts) {
                    sb.Append(vert);
                }
                Debug.Log(sb.ToString());
            }
        }

    }
}