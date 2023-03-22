using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealhSystem : MonoBehaviour, IDamageable
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
        if((Health - damage) <= 0)
        {
            Die();
        }
    }
    protected void Die()
    {
        Destroy(this);
    }

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            Damage(1f);
        }
    }
}
