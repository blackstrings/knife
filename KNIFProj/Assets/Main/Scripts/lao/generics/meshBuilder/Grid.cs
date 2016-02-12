using UnityEngine;
using System.Collections;

namespace LAO.Generic {

    /// <summary>
    /// When you have required components, unity will auto import them on awak
    /// </summary>
    [RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
    public class Grid : MonoBehaviour {

        public int xSize, ySize;

        void Awake() {

            //StartCoroutine(generate());   //turn on to see slow generation of mesh

            generateInstantly(); //turn on to get instantly the mesh
        }

        private Vector3[] vertices;
        private Mesh mesh;

        //generate the vertices and space them out accordingly
        private void generateInstantly() {

            GetComponent<MeshFilter>().mesh = mesh = new Mesh();
            mesh.name = "Procedural Grid";

            //vertices
            vertices = new Vector3[(xSize + 1) * (ySize + 1)];

            //UV
            Vector2[] uv = new Vector2[vertices.Length];

            //tangents for bump maps and heights if material supports
            Vector4[] tangents = new Vector4[vertices.Length];
            Vector4 tangent = new Vector4(1f, 0f, 0f, -1f);

            //space out the vertices
            for (int i = 0, y = 0; y <= ySize; y++) {
                for (int x = 0; x <= xSize; x++, i++) {
                    //vertices
                    vertices[i] = new Vector3(x, y);

                    //uv
                    uv[i] = new Vector2((float)x / xSize, (float)y / ySize);

                    //tangents for bump maps, all tangents simply point to the same direction which is right
                    tangents[i] = tangent;
                }
            }

            //pass our data to the mesh
            mesh.vertices = vertices;
            mesh.uv = uv;
            mesh.tangents = tangents;

            //give triangles to the vertices in order to see it in playmode
            //the order of the vertices clockwise is visible, while counter-colockwise is not rendered

            /*
            int[] triangles = new int[3];
            //the first triangle
            triangles[0] = 0;
            triangles[1] = xSize + 1;
            triangles[2] = 1;

            //the 2nd triangle
            triangles[3] = 1;
            triangles[4] = xSize + 1;
            triangles[5] = xSize + 2;
            */

            //because the trianbles share two vertices
            //we can convert the above code into 4 lines of code
            /*
            triangles[0] = 0;
            triangles[3] = triangles[2] = 1;
            triangles[4] = triangles[1] = xSize + 1;
            triangles[5] = xSize + 2;
            */

            //we can create the first row by putting above into a loop
            /*
            int[] triangles = new int[xSize * 6];
            for (int ti = 0, vi = 0, x = 0; x < xSize; x++, ti += 6, vi++) {
                triangles[ti] = vi;
                triangles[ti + 3] = triangles[ti + 2] = vi + 1;
                triangles[ti + 4] = triangles[ti + 1] = vi + xSize + 1;
                triangles[ti + 5] = vi + xSize + 2;
                mesh.triangles = triangles; //to see our triangle appear one by one
                yield return wait;
            }
            */

            //put it into a double loop and we can see the y and x build
            int[] triangles = new int[xSize * ySize * 6];
            for (int ti = 0, vi = 0, y = 0; y < ySize; y++, vi++) {
                for (int x = 0; x < xSize; x++, ti += 6, vi++) {
                    triangles[ti] = vi;
                    triangles[ti + 3] = triangles[ti + 2] = vi + 1;
                    triangles[ti + 4] = triangles[ti + 1] = vi + xSize + 1;
                    triangles[ti + 5] = vi + xSize + 2;
                    // mesh.triangles = triangles; //to see our triangle appear one by one
                }
            }

            mesh.triangles = triangles; //to see all our trinalges at the end

            //genereate normals, without normals, you will not get light variation hit surfaces and just one plain color regardless of light angle
            //The default normal direction is (0, 0, 1) which is the exact opposite of what we need.
            //we can be lazy and use the normals based on its triangles
            mesh.RecalculateNormals();

        }

        //generate the vertices and space them out accordingly
        private IEnumerator generate() {

            //so we can see how our vertices is being built slowly
            WaitForSeconds wait = new WaitForSeconds(.05f);

            GetComponent<MeshFilter>().mesh = mesh = new Mesh();
            mesh.name = "Procedural Grid";

            vertices = new Vector3[(xSize + 1) * (ySize + 1)];

            //UV
            Vector2[] uv = new Vector2[vertices.Length];

            //space out the vertices
            for (int i = 0, y = 0; y <= ySize; y++) {
                for (int x = 0; x <= xSize; x++, i++) {
                    vertices[i] = new Vector3(x, y);

                    //uv
                    uv[i] = new Vector2((float)x / xSize, (float)y / ySize);

                    yield return wait;

                }
            }

            //pass our vertices to the mesh vertices
            mesh.vertices = vertices;
            mesh.uv = uv;

            //give triangles to the vertices in order to see it in playmode
            //the order of the vertices clockwise is visible, while counter-colockwise is not rendered


            /*
            int[] triangles = new int[3];
            //the first triangle
            triangles[0] = 0;
            triangles[1] = xSize + 1;
            triangles[2] = 1;

            //the 2nd triangle
            triangles[3] = 1;
            triangles[4] = xSize + 1;
            triangles[5] = xSize + 2;
            */

            //because the trianbles share two vertices
            //we can convert the above code into 4 lines of code
            /*
            triangles[0] = 0;
            triangles[3] = triangles[2] = 1;
            triangles[4] = triangles[1] = xSize + 1;
            triangles[5] = xSize + 2;
            */

            //we can create the first row by putting above into a loop
            /*
            int[] triangles = new int[xSize * 6];
            for (int ti = 0, vi = 0, x = 0; x < xSize; x++, ti += 6, vi++) {
                triangles[ti] = vi;
                triangles[ti + 3] = triangles[ti + 2] = vi + 1;
                triangles[ti + 4] = triangles[ti + 1] = vi + xSize + 1;
                triangles[ti + 5] = vi + xSize + 2;
                mesh.triangles = triangles; //to see our triangle appear one by one
                yield return wait;
            }
            */

            //put it into a double loop and we can see the y and x build
            int[] triangles = new int[xSize * ySize * 6];
            for (int ti = 0, vi = 0, y = 0; y < ySize; y++, vi++) {
                for (int x = 0; x < xSize; x++, ti += 6, vi++) {
                    triangles[ti] = vi;
                    triangles[ti + 3] = triangles[ti + 2] = vi + 1;
                    triangles[ti + 4] = triangles[ti + 1] = vi + xSize + 1;
                    triangles[ti + 5] = vi + xSize + 2;
                    mesh.triangles = triangles; //to see our triangle appear one by one
                    yield return wait;
                }
            }

            //genereate normals, without normals, you will not get light variation hit surfaces and just one plain color regardless of light angle
            //The default normal direction is (0, 0, 1) which is the exact opposite of what we need.
            //we can be lazy and use the normals based on its triangles
            mesh.RecalculateNormals();

        }

        //use draw gizmos to quick see references of our vertices
        //turn this on only when you want to see in debug mode of the vertices
        private void OnDrawGizmos() {
            if (vertices == null) {
                return;
            }

            Gizmos.color = Color.black;
            for (int i = 0; i < vertices.Length; i++) {
                Gizmos.DrawSphere(vertices[i], 0.1f);
            }
        }
    }
}