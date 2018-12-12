using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BookStatusScript : MonoBehaviour {

    public Image bookImagePrefab;

    public void AddBook()
    {
        Instantiate(bookImagePrefab, transform);
    }

    public void RemoveBook()
    {
        Image i = GetComponentInChildren<Image>();
        if (i != null)
            Destroy(i.gameObject);
    }
}
