using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heal : MonoBehaviour
{
    [SerializeField] Player player;
    [SerializeField] int heal;
    [SerializeField] TagId targetTag;
    public int limit =10;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals(targetTag.ToString()))
        {
            player.health += heal;
            if (player.health >= limit )
                player.health = limit;
            for (int i = 0; player.health > i; i++)
            {
                player.hearths[i].SetActive(true);
            }
            Destroy(this.gameObject);
        }
    }
}
