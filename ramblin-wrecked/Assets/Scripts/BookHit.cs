using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class BookHit : MonoBehaviour {

    void OnTriggerEnter(Collider c)
    {
        if (c.gameObject.tag == "Player")
        {
            FixedPlayerMovement bc = c.attachedRigidbody.gameObject.GetComponent<FixedPlayerMovement>();
            if (bc != null)
            {
                bc.booksNum += 1;

                AudioSource sfx = GetComponent<AudioSource>();
                if (sfx != null)
                    sfx.Play();

                GetComponent<BoxCollider>().enabled = false;
                StartCoroutine("DelayAfterSoundEffect");
            }
        }
    }

    IEnumerator DelayAfterSoundEffect()
    {
        yield return new WaitForSecondsRealtime(0.5f);
        AfterSoundEffect();
        yield return null;
    }

    void AfterSoundEffect()
    {
        gameObject.SetActive(false);
    }
}
