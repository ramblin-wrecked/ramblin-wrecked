using UnityEngine;
using System.Collections;

public class StatusManager : MonoBehaviour
{
    
    public BookStatusScript bookStatusManager;

    Animator anim;

    public bool drunk = false;
    bool hyper = false;
    int bookNum = 0;

    FixedPlayerMovement pm;

    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
        pm = GameObject.FindGameObjectWithTag("Player").GetComponent<FixedPlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if ((pm.curDizzyDuration > 0 && !drunk) || (pm.curDizzyDuration <= 0 && drunk))
        {
            anim.SetTrigger("ToggleDrunk");
            drunk = !drunk;
        }

        if ((pm.curHyperDuration > 0 && !hyper) || (pm.curHyperDuration <= 0 && hyper))
        {
            anim.SetTrigger("ToggleHyper");
            hyper = !hyper;
        }

        if (pm.booksNum > 0 && bookNum == 0)
            bookStatusManager.gameObject.SetActive(true);
        if (pm.booksNum > bookNum)
        {
            bookStatusManager.AddBook();
            bookNum++;
        }
        if (pm.booksNum < bookNum)
        {
            bookStatusManager.RemoveBook();
            bookNum--;
        }
        if (bookNum == 0)
            bookStatusManager.gameObject.SetActive(false);
    }
}
