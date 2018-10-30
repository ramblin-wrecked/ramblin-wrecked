using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeKeeper : MonoBehaviour {

    static float time;
    static float dt;
    public static bool isPaused;

	// Use this for initialization
	void Start () {
        time = 0f;
        isPaused = false;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        dt = isPaused ? 0f : Time.deltaTime;
        time += dt;
	}

    public static float GetTime()
    {
        return time;
    }

    public static float GetDeltaTime()
    {
        return dt;
    }
}
