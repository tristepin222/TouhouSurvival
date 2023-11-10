using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class HealthSystem : MonoBehaviour, IDamageable
{
    [SerializeField] protected float baseHealth;
    [SerializeField] protected LootSystem Ls;
    [SerializeField] protected BossSystem boss;
    float currentHealth;

    protected virtual void Start()
    {
        Health = baseHealth;
    }

    public float Health 
    { 
        get 
        { 
            return currentHealth; 
        } 
        set 
        { 
            currentHealth = value;
        } 
    }

    public void Damage(float damage)
    {
        Health -= damage;
        if((Health - damage) < 0)
        {
            Die();
        }
    }
    protected virtual void Die()
    {
        if(boss!= null)
        {
            boss.Die();
        }
        if (Ls != null)
        {
            Ls.Loot();
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    protected virtual void OnCollisionEnter2D(Collision2D collision)
    {

    }

    public class EmptyHealthException : Exception { }
}

