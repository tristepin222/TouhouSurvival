using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;
using System;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using System;

public class Weapon : MonoBehaviour
{
    [SerializeField] int damage;
    [SerializeField] bool trackMouse;
    [SerializeField] GameObject player;
    private bool canAttack = true;

    [Serializable]
    public class OnAttackEvent : UnityEvent { }
    [Serializable]
    public class OnResetEvent : UnityEvent { }

    [SerializeField]
    private OnAttackEvent m_OnAttack = new OnAttackEvent();
    [SerializeField]
    private OnResetEvent m_OnReset = new OnResetEvent();

    private void Start()
    {
        Damage = damage;
    }
    public int Damage{ get; set; }

    private void Update()
    {
        if (canAttack) 
        { 
            if (trackMouse)
            {
                CalculateRotation();
            }
            else
            {
                CalculateRotationFromMouse();
            }
        }
    }

    private void CalculateRotation()
    {
        Vector3 vector3 = Camera.main.WorldToScreenPoint(player.transform.position);
        vector3 = Input.mousePosition - vector3;
        float angle = Mathf.Atan2(vector3.y, vector3.x) * Mathf.Rad2Deg;

        this.transform.position = player.transform.position;
        transform.position = new Vector2(transform.position.x, transform.position.y - 0.07f);
        this.transform.rotation = Quaternion.AngleAxis(angle + 90, Vector3.forward);
    }

    private void CalculateRotationFromMouse()
    {
        Vector3 mousePosition = Input.mousePosition;
        Vector3 objectPosition = Camera.main.WorldToScreenPoint(transform.position);
        mousePosition.z = 0;
        mousePosition -= objectPosition;
        float angle = Mathf.Atan2(mousePosition.y, mousePosition.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle + 90, Vector3.forward);
    }
    public void Attack()
    {
        if (canAttack)
        {
            trackMouse = false;
            m_OnAttack.Invoke();
        }
    }


    public IEnumerator ResetAnimation()
    {
        yield return 0;
        m_OnReset.Invoke();
        trackMouse = true;
    }

    public void Hit(HealthSystem healthSystem)
    {
        healthSystem.Damage(Damage);
    }

    public void Disable()
    {
        canAttack = false;
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
