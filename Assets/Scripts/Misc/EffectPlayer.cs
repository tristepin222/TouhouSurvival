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
    public class OnEffectEvent : UnityEvent { }

    [SerializeField] Animator animator;
    [SerializeField] VisualEffect visualEffect;
    [SerializeField] Death[] deaths;
    [SerializeField] bool isRandom = false;
    [SerializeField] bool isCentered = false;
    [SerializeField] float time;
    [SerializeField] AudioSource audioSource;
    [SerializeField]
    private OnEffectEvent m_OnEffectStart = new OnEffectEvent();

    public void StopAllAIs()
    {
        AIPath[] gameObjects = FindObjectsOfType<AIPath>();

        foreach (AIPath gameObject in gameObjects)
        {
            gameObject.canMove = false;
        }
    }
    public IEnumerator PlayEffect(int index = 0, bool invoke = true)
    {
        yield return new WaitForSeconds(time);
        if (invoke)
        {
            m_OnEffectStart.Invoke();
        }
        if (isRandom)
        {
            visualEffect.SendEvent(deaths[index].eventName);
        }
        else
        {
            visualEffect.SendEvent(deaths[0].eventName);
        }
    }

    public void PlayAnimation()
    {
        if (isCentered)
        {
            this.transform.position = GameObject.FindGameObjectWithTag("Player").transform.position;
        }
        m_OnEffectStart.Invoke();
        if (isRandom)
        {
            int index = UnityEngine.Random.Range(0, deaths.Length);
            animator.Play(deaths[index].animationName);
            if (deaths[index].clip != null)
            {
                audioSource.clip = deaths[index].clip;
            }
            StartCoroutine(PlayEffect(index, false));
        }
        else
        {
            animator.Play(deaths[0].animationName);
        }
    }
    public void PlaySound()
    {
        audioSource.Play();
    }

    public void StopEffect()
    {
        visualEffect.Stop();
    }

    public OnEffectEvent onEffectStart
    {
        get { return m_OnEffectStart; }
        set { m_OnEffectStart = value; }
    }
}
