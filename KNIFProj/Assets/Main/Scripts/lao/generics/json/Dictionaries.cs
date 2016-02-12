using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace LAO.Generic {

    public class Dictionaries : MonoBehaviour {

        // Use this for initialization
        void Start() {

            //Dictionary<int, DicItemDTO> mList = new Dictionary<int, DicItemDTO>();
            Dictionary<int, string> mList = new Dictionary<int, string>();

            //	mList.Add(1000, new DicItemDTO());
            mList.Add(1001, "one");
            mList.Add(1002, "two");

            Debug.Log(mList.Count);
            if (mList.ContainsKey(1002)) {
                Debug.Log(mList[1002]);
            }

            int key = 1006;
            string val;
            if (mList.TryGetValue(key, out val)) {
                Debug.Log(val);
            } else {
                Debug.Log(key + " not found");
            }

        }
        
    }
}