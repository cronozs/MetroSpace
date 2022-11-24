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

    [SerializeField] Transform player;
    [SerializeField] float speed;
    public bool perseguir = false;

    private bool attack;
    [SerializeField] float espera;
    [SerializeField] float tiempoattack;
    private Vector3 playerPos;
    public bool acive = false;
    private void Update()
    { 
        if (acive)
        {
            EnemyAtack();
        }
    }
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

    private void EnemyAtack()
    {
        tiempoattack -= Time.deltaTime;
        if (tiempoattack <= 0)
        {
            attack = true;
            perseguir = true;
        }
        if (attack)
        {
            playerPos = player.position;
            attack = false;
            tiempoattack = espera;
            return;
        }
        if (perseguir)
        {
            this.transform.position = Vector2.MoveTowards(this.transform.position, playerPos, speed * Time.deltaTime);
            if (tiempoattack <= espera/2)
            {
                perseguir = false;
            }
        }
        else
        {
            this.transform.position = Vector2.MoveTowards(this.transform.position, new Vector2(20,5), speed * Time.deltaTime);

        }
    }
}
