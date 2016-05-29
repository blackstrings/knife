using UnityEngine;
using System.Collections;
using LAO.Generic;

public class TempSingleton : Singleton<TempSingleton> {

    public GameObject activeGO { get; set; }

	public GameObject getActiveGO() {
        if (activeGO) {
            return activeGO;
        }
        return null;
    }

}
