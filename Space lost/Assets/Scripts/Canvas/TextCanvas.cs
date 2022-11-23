using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextCanvas : MonoBehaviour
{
    [SerializeField] GameObject canva;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        canva.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        canva.SetActive(false);
    }
}
