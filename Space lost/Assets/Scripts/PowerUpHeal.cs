using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpHeal : MonoBehaviour
{
    [SerializeField] TagId targetTag;
    [SerializeField] Heal heal;
    [SerializeField] int aumento;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag.Equals(targetTag.ToString()))
        {
            heal.limit += aumento;
            Destroy(this.gameObject);
        }
    }
}
