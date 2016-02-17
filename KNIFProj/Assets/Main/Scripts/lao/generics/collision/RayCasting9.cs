using UnityEngine;
using System.Collections;

namespace LAO.Generic {

    /// <summary>
    /// Ray casting, put on main camera or any game object and will detect any collisions mouse hits
    /// Shows line drawn in the UI
    /// </summary>
    public class RayCasting9 : MonoBehaviour {

        // Update is called once per frame
        void Update() {

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100))
                Debug.DrawLine(ray.origin, hit.point);

        }
    }
}
