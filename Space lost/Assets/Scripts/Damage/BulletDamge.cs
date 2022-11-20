using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDamge : MonoBehaviour
{
    [SerializeField] public int damagePoints;
    [SerializeField] TagId targetTag;
  
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("si esta trigger");
        if (collision.gameObject.tag.Equals(targetTag.ToString()))
        {
            var component = collision.gameObject.GetComponent<ICombat>();
            if (component != null)
            {
                component.TakeDamage(damagePoints);
            }

        }

    }
}
