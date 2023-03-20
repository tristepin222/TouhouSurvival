using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour, IDamageable
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
        if ((Health - damage) < 0)
        {
            Die();
        }
    }
    private void Die()
    {
        Destroy(this.gameObject);
    }
}
