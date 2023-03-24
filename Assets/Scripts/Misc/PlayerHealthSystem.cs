using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthSystem : HealthSystem
{
    [SerializeField] public EffectPlayer effectPlayer;
    [SerializeField] public new Rigidbody2D rigidbody2D;
    [SerializeField] public FightSystem fightSystem;
    protected override void Die()
    {
        if(effectPlayer == null)
        {
            throw new EmptyException.EmptyEffectPlayerException();
        }
        if (rigidbody2D == null)
        {
            throw new EmptyException.EmptyRigidbody2DException();
        }
        if (fightSystem == null)
        {
            throw new EmptyException.EmptyFightSystemException();
        }
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