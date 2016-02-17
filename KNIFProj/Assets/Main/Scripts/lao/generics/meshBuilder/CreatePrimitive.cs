using UnityEngine;
using System.Collections;

namespace LAO.Generic {

    /// <summary>
    /// This class creates a primitive cube and explodes the faces
    /// </summary>
    public class CreatePrimitive : MonoBehaviour {

        GameObject locator;
        GameObject cube;

        private void test() {
            Debug.Log(locator);
        }
        void Start() {

            //GameObject plane = GameObject.CreatePrimitive(PrimitiveType.Plane);
            locator = new GameObject();

            //how to createa  primitive cube nothing more
            cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            cube.transform.position = new Vector3(0, 0, 0);

            explodeFaces(cube);

        }

        void Update() {

        }

        void explodeFaces(GameObject go) {


            // get the gameobject's mesh
            Mesh mesh = go.gameObject.GetComponent<MeshFilter>().mesh;

            // get the mesh's vertices & normals
            Vector3[] vertices = mesh.vertices;
            Vector3[] normals = mesh.normals;


            // loop through all vertices ** note that normals are the same amount as vertices
            for (int i = 0; i < vertices.Length; i++) {
                vertices[i] += normals[i] * 1;
            }


            // assign the vertices back to the gameobject mesh
            mesh.vertices = vertices;

        }
    }
}
