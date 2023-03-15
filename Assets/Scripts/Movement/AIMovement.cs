using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
public class AIMovement : Movement
{
    [SerializeField] AIDestinationSetter aIDestinationSetter;
    [SerializeField] AIPath aIPath;

    protected override void Start()
    {
        base.Start();
        aIDestinationSetter.target = GameObject.FindGameObjectWithTag("Player").gameObject.transform;

    }

    protected override void FixedUpdate()
    {
       
    }
    protected override void Update()
    {

        animator.SetFloat("VelocityX", aIPath.velocity.normalized.x);
        animator.SetFloat("VelocityY", aIPath.velocity.normalized.y);

        if (!aIPath.velocity.Equals(Vector2.zero))
        {
            walkEffect.Stop();
        }
        else
        {
            walkEffect.SendEvent("Play");
        }
    }
}
