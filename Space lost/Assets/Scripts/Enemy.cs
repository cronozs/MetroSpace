using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, ICombat
{
    [SerializeField] int health;

    public void TakeDamage(int damagePoints)
    {
        health -= damagePoints;
        if (health == 0)
        {
            Destroy(gameObject);
        }

    }
}
