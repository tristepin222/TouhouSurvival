using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
public class AIMovement : Movement
{
    [SerializeField] AIDestinationSetter aIDestinationSetter;
    [SerializeField] AIPath aIPath;
    [SerializeField] bool isStatic;
    [SerializeField] bool isLinear;
    protected override void Start()
    {
        base.Start();
        GameObject target = GameObject.FindGameObjectWithTag("Player").gameObject;
        if (!isStatic)
        {
            aIDestinationSetter.target = target.transform;
        }
        if (isLinear)
        {
            rigidbody2D.AddForce((target.transform.position - transform.position) * speed);
        }

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
