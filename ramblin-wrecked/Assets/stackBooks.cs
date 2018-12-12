using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stackBooks : MonoBehaviour {
    public GameObject target;
    public GameObject[] books = new GameObject[4];

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
        if (target == null)
        {
            Debug.Log("Player not found");
        }
    }

    private void Update()
    {
        FixedPlayerMovement bc = target.gameObject.GetComponent<FixedPlayerMovement>();
        int bookAm = bc.booksNum;
        if(bookAm > 0)
        {
            for(int i = 0; i < bookAm; i++)
            {
                books[i]
            }
        }
    }
}
