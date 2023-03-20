using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealhSystem : MonoBehaviour, IDamageable
{
    [SerializeField] float baseHealth;

    private void Start()
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
    private void Die()
    {
        Destroy(this);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            Damage(1f);
        }
    }
}
