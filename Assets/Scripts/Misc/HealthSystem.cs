using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour, IDamageable
{
    [SerializeField] float baseHealth;

    protected void Start()
    {
        Health = baseHealth;
    }

    public float Health { get; set; }

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
}