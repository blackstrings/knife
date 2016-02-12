using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace LAO.Generic.Gui {

    /// <summary>
    /// This scripts Requires the new gui scroll bar
    /// Attach this script to a empty parent gameobject
    /// The parent should have a 3d model/prefab as a child.
    /// Create a new gui scroll bar under the canvas gameobject
    /// Then map the new Gui scrollbar's on value change editor to call the action() method.
    /// </summary>
    public class ScrollBarRotateGO : MonoBehaviour {
        
        public GameObject go_sb;
        private Scrollbar sb;

        // Use this for initialization
        void Start() {
            sb = go_sb.GetComponent<Scrollbar>();
            sb.onValueChanged.AddListener(value => action(value));
        }

        private float x = 0f;

        //max angle can rotate based on slider
        //if you want to do 360, change value to 180
        public float angle = 180f;
        float rotation = 0f;

        /// <summary>
        /// You can take percent times the max and get a good 1:1.
        /// But when you need to start rotation at a certain degree and map it to another
        /// this is one solution
        /// </summary>
        /// <param name="percent"></param>
        public void action(float percent) {   //0.0 - 1.0
            rotation = ((angle * 2) * percent) - angle;
            x = rotation;
            //some additional stuff
            //scaledValue = (rawValue - min) / (max - min);
        }

        // Update is called once per frame
        void Update() {
            //adding degree to current rotation value
            //this.gameObject.transform.Rotate(new Vector3(0, degree, 0));
            this.gameObject.transform.localEulerAngles = new Vector3(0, x, 0);
        }
    }
}
