using UnityEngine;
using System.Collections;
using System.Collections.Generic;


namespace LAO.Generic {

    /// <summary>
    /// This class creates a primitive cube and explodes the faces
    /// </summary>
    public class CreateStructure : MonoBehaviour {

        GameObject locator;
        GameObject floor;

        void Start() {

            // garage test dimension
            float width = 10.0f;
            float length = 25.0f;
            float height = 10.0f;

            //create3DStructure();

            //4 sided floor
            //create primitive floor > reposition > rotate to face up > scale to dimension
            floor = GameObject.CreatePrimitive(PrimitiveType.Quad);
            floor.transform.position = new Vector3(0, 0, 0);
            floor.transform.Rotate(new Vector3(90, 0, 0));
            floor.transform.localScale = new Vector3(width, length, 1f);// = 5f;
            floor.gameObject.GetComponent<MeshFilter>().mesh.RecalculateBounds();
            floor.gameObject.GetComponent<MeshFilter>().mesh.RecalculateNormals();

            // **** scale does not update vertices, fix that

            //for (int i = 0; i < edges.Length; i++)
            //{
            //    print(i + ": " + edges[i].v1 + ", " + edges[i].v2);
            //}

            // http://answers.unity3d.com/questions/297453/finding-locations-of-vertices-on-a-mesh.html
            // http://answers.unity3d.com/questions/566779/how-to-find-the-vertices-of-each-edge-on-mesh.html
            // Answer lies somehwere here http://docs.unity3d.com/ScriptReference/Mesh.html
            /*
            Bounds b = new Bounds();
            b = floor.GetComponents<Bounds>().GetValue(0);
            Debug.Log( b.ToString() );
            */

            Dictionary<string, List<Vector3>> Dsides = new Dictionary<string, List<Vector3>>();

            ///////////////////////////
            // get garage # of walls //
            ///////////////////////////

            // get the gameobject's mesh
            Mesh mesh = floor.gameObject.GetComponent<MeshFilter>().mesh;

            // get the mesh's vertices & normals
            Vector3[] vertices = mesh.vertices;
            Vector3[] normals = mesh.normals;
            Debug.Log("test: " + normals + " : " + height);

            // loop through all vertices ** note that normals are the same amount as vertices
            for (int i = 0; i < vertices.Length; i++) {


                // validate we are not at last vertex index, as +1 will go over index
                if (i != vertices.Length - 1) {

                    // for each side, store vertex A & B
                    List<Vector3> coords = new List<Vector3>();
                    coords.Add(vertices[i]);
                    coords.Add(vertices[i + 1]);
                    Dsides.Add("segment" + i, coords);

                } else {

                    // for last side, store vertex[end] to vertext[0]
                    List<Vector3> coords = new List<Vector3>();
                    coords.Add(vertices[i]);
                    coords.Add(vertices[0]);
                    Dsides.Add("segment" + i, coords);

                }

            }

            //test
            List<Vector3> newVList = Dsides["segment1"];
            Debug.Log(newVList[0] + " : " + newVList[1]);

            // create the walls
            for (int i = 0; i < Dsides.Count; i++) {

                //get the xyz coordnite per wall
                List<Vector3> segments = Dsides["segment" + i];

                // create wall
                GameObject wall = GameObject.CreatePrimitive(PrimitiveType.Cube);
                wall.transform.position = segments[0];  // always segement 0

            }





            /*
            // assign the vertices back to the gameobject mesh
            mesh.vertices = vertices;

            Wall wall = new Wall(width, height, length);

            ArrayList garageData = new ArrayList();


            //GameObject plane = GameObject.CreatePrimitive(PrimitiveType.Plane);
            locator = new GameObject();
            */

        }



    }
}
