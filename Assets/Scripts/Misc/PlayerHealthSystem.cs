using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthSystem : HealthSystem
{
    [SerializeField] EffectPlayer effectPlayer;
    [SerializeField] new Rigidbody2D rigidbody2D;
    [SerializeField] FightSystem fightSystem;
    protected override void Die()
    {
        fightSystem.DisableWeapons();
        effectPlayer.StopAllAIs();
        rigidbody2D.constraints = RigidbodyConstraints2D.FreezeAll;
        effectPlayer.PlayAnimation();
    }
    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Enemy")
        {
            Damage(1f);
        }
    }
}