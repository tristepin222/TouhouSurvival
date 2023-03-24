using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using System;

public class PlayerHealthSystem : HealthSystem
{
    [Serializable]
    public class OnDeathEvent : UnityEvent { }

    [SerializeField] public new Rigidbody2D rigidbody2D;

    [SerializeField]
    private OnDeathEvent m_OnDeath = new OnDeathEvent();

    protected override void Die()
    {
        if (rigidbody2D == null)
        {
            throw new EmptyException.EmptyRigidbody2DException();
        }
        rigidbody2D.constraints = RigidbodyConstraints2D.FreezeAll;
        m_OnDeath.Invoke();
    }
    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Enemy")
        {
            Damage(1f);
        }
    }

    public OnDeathEvent onEffectStart
    {
        get { return m_OnDeath; }
        set { m_OnDeath = value; }
    }
}