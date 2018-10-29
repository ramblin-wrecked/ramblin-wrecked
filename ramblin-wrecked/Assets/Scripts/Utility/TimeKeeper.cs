using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeKeeper : MonoBehaviour {

    public static float time;
    public static bool notPaused;
	
	// Update is called once per frame
	void FixedUpdate () {
        if (TimeKeeper.notPaused)
            TimeKeeper.time += Time.deltaTime;
	}
}
