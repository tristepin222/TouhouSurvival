using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
using UnityEngine.VFX;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using System;

public class EffectPlayer : MonoBehaviour
{
    [Serializable]
    public class ButtonClickedEvent : UnityEvent { }

    [SerializeField] Animator animator;
    [SerializeField] VisualEffect visualEffect;
    [SerializeField] string eventName;
    [SerializeField] string animationName;
    [SerializeField] bool isCentered = false;
    [SerializeField]
    private ButtonClickedEvent m_OnEffectStart = new ButtonClickedEvent();

    public void StopAllAIs()
    {
        AIPath[] gameObjects = FindObjectsOfType<AIPath>();

        foreach (AIPath gameObject in gameObjects)
        {
            gameObject.canMove = false;
        }
    }
    public void PlayEffect()
    {
        m_OnEffectStart.Invoke();
        visualEffect.SendEvent(eventName);
    }

    public void PlayAnimation()
    {
        if (isCentered)
        {
            this.transform.position = GameObject.FindGameObjectWithTag("Player").transform.position;
        }
        m_OnEffectStart.Invoke();
        animator.Play(animationName);
    }

    public void StopEffect()
    {
        visualEffect.Stop();
    }

    public ButtonClickedEvent onEffectStart
    {
        get { return m_OnEffectStart; }
        set { m_OnEffectStart = value; }
    }
}
