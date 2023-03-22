using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EffectPlayer : MonoBehaviour
{
    [SerializeField] Animator animator;
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
