using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour {

    public GameObject cup;

    float xPos;
    float yPos;
    float zPos;
    float[] allX = new float[3];

    public void Start()
    {
        for (int i = 0; i<3; i++)
        {
            SpawnObject(i);
        }
    }

    public void SpawnObject(int i)
    {

        xPos = Random.Range(-5500,2000);

        if (i > 0) {
            float tmp = allX[i--];
            if (xPos <= (500 + tmp) && xPos >= (tmp - 500)) {
                xPos = Random.Range(tmp + 500, 2000);
            }
        }
        if (i == 2)
        {
            float tmp = allX[0];
            if (xPos <= (500 + tmp) && xPos >= (tmp - 500))
            {
                xPos = Random.Range(tmp + 500, 2000);
            }
        }
        allX[i] = xPos;

        yPos = -148;
        zPos = 248;
        Instantiate(cup, new Vector3(xPos, yPos, zPos), new Quaternion(0, 180, 0, 0));
    }


}
