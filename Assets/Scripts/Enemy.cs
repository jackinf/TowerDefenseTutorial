﻿using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    private float health;

    public float startSpeed = 10f;
    public float startHealth = 100f;
    [HideInInspector] public float speed;
    public int priceValue = 50;
    public GameObject deathEffect;

    [Header("Unity Stuff")] public Image healthBar;

    private bool isDead = false;
    
    private void Start()
    {
        speed = startSpeed;
        health = startHealth;
    }

    public void TakeDamage(float amount)
    {
        health -= amount;

        healthBar.fillAmount = health / startHealth;
        
        if (health <= 0f && !isDead)
        {
            health = 0;
            Die();
        }
    }

    public void Slow(float slowAmount)
    {
        speed = startSpeed * (1 - slowAmount);
    }

    private void Die()
    {
        isDead = true;
        
        Destroy(Instantiate(deathEffect, transform.position, Quaternion.identity), 5f);

        WaveSpanner.EnemiesAlive--;
        Debug.Log($"Enemies Left: {WaveSpanner.EnemiesAlive}");
        
        PlayerStats.Money += priceValue;
        Destroy(gameObject);
    }
}
