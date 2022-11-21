using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, ICombat
{
    [SerializeField] int health;
    [SerializeField] Animator animator;
    [SerializeField] DamageFeedbackEffect damageFeedbackEffect;
    public void TakeDamage(int damagePoints)
    {
        health -= damagePoints;
        damageFeedbackEffect.PlayDamageEffect();
        if (health <= 0)
        {
            animator.Play("Enemy Death");
            Destroy(gameObject);
        }

    }
}
