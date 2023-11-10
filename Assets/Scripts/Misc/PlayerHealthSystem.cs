using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using System;
using UnityEngine.SceneManagement;

public class PlayerHealthSystem : HealthSystem
{
    [Serializable]
    public class OnDeathEvent : UnityEvent { }

    [SerializeField] public new Rigidbody2D rigidbody2D;
    [SerializeField] bool isDead;
    [SerializeField] UIHealthSystem healthSlider; 

    [SerializeField]
    private OnDeathEvent m_OnDeath = new OnDeathEvent();
    [SerializeField]
    Collider2D collider;
    protected override void Start()
    {
        healthSlider = FindFirstObjectByType<UIHealthSystem>();
        GlobalController.Instance.isDead = false;
        baseHealth += GlobalController.Instance.bonusHealthAmount;
        base.Start();
        healthSlider.SetSlider(baseHealth, Health);
    }

    protected override void Die()
    {
        if (!isDead)
        {
            if (rigidbody2D == null)
            {
                throw new EmptyException.EmptyRigidbody2DException();
            }
            rigidbody2D.constraints = RigidbodyConstraints2D.FreezeAll;
            m_OnDeath.Invoke();
            isDead = true;
            GlobalController.Instance.isDead = true;
        }
    }
    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Enemy")
        {
            Damage(1f);
            healthSlider.SetSlider(baseHealth, Health);
            collision.gameObject.GetComponent<LootSystem>().Loot();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
       
        if (collision.transform.tag == "EnemyBullet")
        {
            if (collision.IsTouching(collider))
            {
                Damage(1f);
                healthSlider.SetSlider(baseHealth, Health);
                Destroy(collision.gameObject);
            }
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene("Menu");
    }

    public OnDeathEvent onEffectStart
    {
        get { return m_OnDeath; }
        set { m_OnDeath = value; }
    }
}