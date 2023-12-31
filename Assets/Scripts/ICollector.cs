using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ICollector : MonoBehaviour
{
    private int star = 0;
    public Text starText;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Star"))
        {
            Destroy(collision.gameObject);
            star++;
            starText.text = ": "+ star;
        }
    }
}
