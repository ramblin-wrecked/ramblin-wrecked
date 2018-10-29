using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour {

    public GameObject cup;
    public GameObject player;

    float xPos;
    float yPos;
    float zPos;

    const float radius = 0.5f;

    public void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        for (int i = 0; i<3; i++)
        {
            SpawnObject(i);
        }
    }

    public void SpawnObject(int i)
    {
        xPos = i;

        if (xPos < 1)
            xPos = -2000;
        else if (xPos > 1)
            xPos = -2000;
        else
            xPos = 0;
        //This will align your xPos to 2, 0 or -2.

        //zPos = player.transform.position.z + 50;
        //I'm not sure if this is what you want.
        //If not you can simply use the Random class methods
        yPos = -106;
        zPos = 248;
        //yPos = CheckForYPosition();
        Instantiate(cup, new Vector3(xPos, yPos, zPos), new Quaternion(0, 180, 0, 0));
    }


}
