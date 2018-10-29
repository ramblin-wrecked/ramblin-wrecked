using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckCup : MonoBehaviour {

    public bool hitCup = false;


    public void isHit() { hitCup = true; }

    public void outOfBox() { hitCup = false; }
}
