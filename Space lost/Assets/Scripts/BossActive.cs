using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossActive : MonoBehaviour
{
    [SerializeField] Boss boss;

    private void OnTriggerExit2D(Collider2D collision)
    {
        boss.acive = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }
}
