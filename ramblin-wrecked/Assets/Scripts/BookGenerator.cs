using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//TODO - AND HOMEWORKS COLLECTABLES
public class BookGenerator : MonoBehaviour {
    public GameObject[] books = new GameObject[4];
    private GameObject player;
    private int bookInd;
    private float timer;
    //private GameObject[] spBooks = new GameObject[10]; // spawned books


    // Use this for initialization
    void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        bookInd = 0;
        timer = 0;
        
    }

    void SpawnObject()
    {
        for (int i = 0; i < 10; i++)
        {
            if(bookInd == 4)
            {
                bookInd = 0;
            }
            Instantiate(books[(Random.Range(0, books.Length))], new Vector3(player.transform.position.x, player.transform.position.y-100, player.transform.position.z), new Quaternion(0, 0, 0, 0));
        } 
    }



    // Update is called once per frame
    void Update () {
        //if time to spawn another - change X
        timer += Time.deltaTime;
        if(timer >= 2.0)
        {
            SpawnObject();
        }
        
	}

}
