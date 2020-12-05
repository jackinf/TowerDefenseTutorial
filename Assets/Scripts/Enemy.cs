﻿using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float startSpeed = 10f;
    
    [HideInInspector]
    public float speed;

    public float health = 100;

    public int priceValue = 50;

    public GameObject deathEffect;

    private void Start()
    {
        speed = startSpeed;
    }

    public void TakeDamage(float amount)
    {
        health -= amount;
        if (health <= 0f)
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
        Destroy(Instantiate(deathEffect, transform.position, Quaternion.identity), 5f);
        
        PlayerStats.Money += priceValue;
        Destroy(gameObject);
    }
}
