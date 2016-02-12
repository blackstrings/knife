using UnityEngine;
using System.Collections;

namespace LAO.Generic {

    public class ProceduralCube : MonoBehaviour {

        void Awake() {
            //custom create a primitive object
            GameObject plane = new GameObject("CustomPlane");

            // create a meshFilter to hold the object
            MeshFilter meshFilter = (MeshFilter)plane.AddComponent(typeof(MeshFilter));

            // create the mesh
            meshFilter.mesh = CreateMesh(3, 0.5f);
            // add renderer
            MeshRenderer renderer = plane.AddComponent(typeof(MeshRenderer)) as MeshRenderer;
            // decorate renderer material
            renderer.material.shader = Shader.Find("Particles/Additive");

            // new texture & set attributes
            Texture2D tex = new Texture2D(1, 1);
            tex.SetPixel(0, 0, Color.blue);
            tex.Apply();

            // apply texture to renderer
            renderer.material.mainTexture = tex;
            renderer.material.color = Color.blue;
        }

        void Start() {

        }

        private Mesh CreateMesh(float width, float height) {
            Mesh m = new Mesh();
            m.name = "ScriptedMesh";
            m.vertices = new Vector3[] {
            new Vector3(-width, -height, 0.01f),
            new Vector3(width, -height, 0.01f),
            new Vector3(width, height, 0.01f),
            new Vector3(-width, height, 0.01f)
        };
            m.uv = new Vector2[] {
            new Vector2 (0, 0),
            new Vector2 (0, 1),
            new Vector2(1, 1),
            new Vector2 (1, 0)
        };
            m.triangles = new int[] { 0, 1, 2, 0, 2, 3 };
            m.RecalculateNormals();

            return m;
        }

    }
}
