using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Text.RegularExpressions;

public class Refaxiones : MonoBehaviour
{
    [SerializeField] Player Player;
    [SerializeField] TagId targetTag;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals(targetTag.ToString()))
        {
            Player.refax += 1;
            Player.refaxText.text = "X" + Player.refax.ToString();
            Destroy(this.gameObject);
        }
    }
}
