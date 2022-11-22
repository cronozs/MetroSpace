using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CanvasController : MonoBehaviour
{
    public GameObject On;
    public GameObject Off;

    public void Active()
    {
        On.SetActive(true);
    }
    public void Deactive()
    {
        On.SetActive(false);
    }

    public void Changer()
    {
        Off.SetActive(false);
        On.SetActive(true);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Active();

        this.gameObject.SetActive(false);
    }
}
