using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class HealthSystem : MonoBehaviour, IDamageable
{
    [SerializeField] float baseHealth;

    float currentHealth;

    protected void Start()
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
            if(value == 0)
            {
                throw new EmptyHealthException();
            }
            else
            {
                currentHealth = value;
            }
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

