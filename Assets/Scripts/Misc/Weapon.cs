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
    private Vector3 basePos;

    private void Start()
    {
        Damage = damage;
        basePos = child.position;
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
                child.rotation = new Quaternion(0, 0, Quaternion.LookRotation(Vector3.RotateTowards(child.position, enemy.position - new Vector3(0, 0.3f), speed * 100 * Time.deltaTime * attackSpeed, 0f)).z, 0);
                child.position = Vector3.MoveTowards(child.position, enemy.position - new Vector3(0, 0.3f), speed * Time.deltaTime);

            }
            else
            {
                if (child.position != basePos)
                {
                    child.rotation = new Quaternion(0, 0, Quaternion.LookRotation(Vector3.RotateTowards(child.position, Vector3.zero, speed * 100 * Time.deltaTime, 0f)).z, 0);
                    child.localPosition = Vector3.MoveTowards(child.localPosition, Vector3.zero, speed * Time.deltaTime);
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
