using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Boss : MonoBehaviour, ICombat
{
    [SerializeField] int health;
    [SerializeField] Animator animator;
    public TMP_Text enemyHealth;
    [SerializeField] CanvasController canva;
    [SerializeField] DamageFeedbackEffect damageFeedbackEffect;

    private void Start()
    {
        enemyHealth.text = "health: " + health.ToString();
    }
    public void TakeDamage(int damagePoints)
    {
        health -= damagePoints;
        damageFeedbackEffect.PlayDamageEffect();
        enemyHealth.text = "health: " + health.ToString();
        if (health <= 0)
        {
            animator.Play("Enemy Death");
            canva.Deactive();
            Destroy(gameObject);
        }

    }
}
