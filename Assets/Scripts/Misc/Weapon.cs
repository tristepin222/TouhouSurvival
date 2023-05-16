using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;
using System;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class Weapon : MonoBehaviour
{
    [SerializeField] int damage;
    [SerializeField] GameObject player;
    [SerializeField] Transform child;
    [SerializeField] SpriteRenderer sprite;
    [SerializeField] Vector3 basePos;
    private bool canAttack = true;

    [Serializable]
    public class OnAttackEvent : UnityEvent { }
    [Serializable]
    public class OnResetEvent : UnityEvent { }
    public float attackSpeed = 1.0f;

    [SerializeField]
    private OnAttackEvent m_OnAttack = new OnAttackEvent();
    [SerializeField]
    private OnResetEvent m_OnReset = new OnResetEvent();
    private float speed = 5.0f;
    private Transform enemy;
    private bool canMove;

    private void Start()
    {
        Damage = damage;
    }
    public int Damage{ get; set; }

    private void Update()
    {
        if (canAttack)
        {
            if (enemy == null)
            {
                canMove = false;
            }
            if (canMove)
            {
                transform.LookAt(enemy.transform, Vector3.up);
                transform.rotation = new Quaternion(0, 0, transform.rotation.x, 0);
                transform.position = Vector3.MoveTowards(transform.position, enemy.position, speed * Time.deltaTime);
            }
            else
            {
                if (transform.position != basePos)
                {
                    transform.localPosition = Vector3.MoveTowards(transform.localPosition, basePos, speed * Time.deltaTime);
                }
            }
        }
    }

    public void Attack(Transform enemy)
    {
        this.enemy = enemy;
        canMove = true;
        m_OnAttack.Invoke();
    }
    public IEnumerator ResetAnimation()
    {
        yield return 0;
        m_OnReset.Invoke();
    }

    public void Hit(HealthSystem healthSystem)
    {
        healthSystem.Damage(Damage *(GlobalController.Instance.bonusDamage / 100 + 1));
        m_OnReset.Invoke();
        canMove = false;
    }

    public void Disable()
    {
        canAttack = false;
    }

    public void HardDisable()
    {
        this.gameObject.SetActive(false);
    }

    public void SetWeapon(ItemScriptableObject itemScriptableObject)
    {
        sprite.sprite = itemScriptableObject.itemGameSprite[0];
    }

    public OnAttackEvent onAttack
    {
        get { return m_OnAttack; }
        set { m_OnAttack = value; }
    }
    public OnResetEvent onReset
    {
        get { return m_OnReset; }
        set { m_OnReset = value; }
    }
}
