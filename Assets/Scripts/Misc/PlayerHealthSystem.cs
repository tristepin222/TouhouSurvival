using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthSystem : HealthSystem
{
    [SerializeField] EffectPlayer effectPlayer;
    protected override void Die()
    {
        effectPlayer.StopAllAIs();
        base.Die();
    }
    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Enemy")
        {
            Damage(1f);
        }
    }
}