using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class HealthSystem : MonoBehaviour, IDamageable
{
    [SerializeField] protected float baseHealth;

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
        Destroy(this.gameObject);
    }

    protected virtual void OnCollisionEnter2D(Collision2D collision)
    {

    }

    public class EmptyHealthException : Exception { }
}

