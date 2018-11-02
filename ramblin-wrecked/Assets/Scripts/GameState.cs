using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour {

    public static int credits = 0;
    static int maxCreditsPerLevel = 20;

    private void Start()
    {
        credits = 0;
    }

    public static float CalculateGPA()
    {
        return Mathf.Min(4f, (4f * credits / maxCreditsPerLevel) + (10 * credits / (maxCreditsPerLevel * TimeKeeper.GetTime())));
    }
}
