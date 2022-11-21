using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    [SerializeField] int power;
    [SerializeField] TagId targetTag;
    [SerializeField] BulletDamge controller;

    private void Start()
    {
        controller.damagePoints = 1;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals(targetTag.ToString()))
        {
            controller.damagePoints += power;
            Destroy(this.gameObject);
        }
    }
}
