using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, ICombat
{
    [SerializeField] int health;
    [SerializeField] Animator animator;

    public void TakeDamage(int damagePoints)
    {
        health -= damagePoints;
        if (health <= 0)
        {
            animator.Play("Enemy Death");
            Destroy(gameObject);
        }

    }
}
