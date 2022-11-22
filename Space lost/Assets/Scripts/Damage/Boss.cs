using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss : MonoBehaviour, ICombat
{
    [SerializeField] float health;
    [SerializeField] Animator animator;
    public Image barraDeVida;
    [SerializeField] CanvasController canva;
    [SerializeField] DamageFeedbackEffect damageFeedbackEffect;
    [SerializeField] float maxHealth;

   
    public void TakeDamage(int damagePoints)
    {
        health -= damagePoints;
        damageFeedbackEffect.PlayDamageEffect();
        barraDeVida.fillAmount = health / maxHealth;
        if (health <= 0)
        {
            animator.Play("Enemy Death");
            canva.Deactive();
            Destroy(gameObject);
        }

    }
}
