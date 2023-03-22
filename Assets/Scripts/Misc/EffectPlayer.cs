using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
using UnityEngine.VFX;

public class EffectPlayer : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] protected Animator globalAnimator;
    [SerializeField] protected Animator playerAnimator;
    [SerializeField] protected VisualEffect playerVisualEffect;
    public void StopAllAIs()
    {
        AIPath[] gameObjects = FindObjectsOfType<AIPath>();

        foreach (AIPath gameObject in gameObjects)
        {
            gameObject.canMove = false;
        }
    }
    public void PlayDeathAnimation()
    {

    }
}
