using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class SceneChange : MonoBehaviour
{
    public int indice;
    public int Requisito;
    public GameObject canvas;
    public GameObject text;
    [SerializeField] TagId targetTag;
    [SerializeField] Player player;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag.Equals(targetTag.ToString()) && player.refax>= Requisito)
        {
            player.Savedata();
            SceneManager.LoadScene(indice);
        }
        else if (collision.gameObject.tag.Equals(targetTag.ToString()))
        {
            canvas.SetActive(true);
            text.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        canvas.SetActive(false);
        text.SetActive(false);
    }
}
