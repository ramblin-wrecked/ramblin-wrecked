using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckBook : MonoBehaviour {
    public bool hitBook = false;


    public void isHit() { hitBook = true; }

    public void outOfBox() { hitBook = false; }
}
