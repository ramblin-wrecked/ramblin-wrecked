using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeKeeper : MonoBehaviour {

    static float time;
    static float dt;
    public static bool notPaused = true;
	
	// Update is called once per frame
	void FixedUpdate () {
        if (notPaused)
            dt = Time.deltaTime;
        else
            dt = 0f;

        time += dt;
	}

    public static float GetDeltaTime()
    {
        return dt;
    }

    public static float GetTime()
    {
        return time;
    }
}
