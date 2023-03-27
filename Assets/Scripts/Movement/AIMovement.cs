using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
public class AIMovement : Movement
{
    [SerializeField] AIDestinationSetter aIDestinationSetter;
    [SerializeField] AIPath aIPath;
    [SerializeField] bool isStatic;
    [SerializeField] bool isRandom;
    [SerializeField] float randomRadius;
    GameObject target;
    protected override void Start()
    {
        base.Start();
        target = GameObject.FindGameObjectWithTag("Player").gameObject;
        if (!isStatic && !isRandom)
        {
            aIDestinationSetter.target = target.transform;
        }
    }

    protected override void FixedUpdate()
    {
       
    }
    protected override void Update()
    {
        animator.SetFloat("VelocityX", aIPath.velocity.normalized.x);
        animator.SetFloat("VelocityY", aIPath.velocity.normalized.y);
        if (isRandom)
        {
            if (!aIPath.pathPending && (aIPath.reachedEndOfPath || !aIPath.hasPath))
            {
                aIPath.destination = RandomPathFromSphere(target, randomRadius);
                aIPath.SearchPath();
            }
        }
        if (!aIPath.velocity.Equals(Vector2.zero))
        {
            walkEffect.Stop();
        }
        else
        {
            walkEffect.SendEvent("Play");
        }
    }

    private Vector3 RandomPathFromSphere(GameObject player, float randomRadius)
    {
        Vector3 point = Random.insideUnitSphere * randomRadius;
        point.y = 0;
        point += player.transform.position;
        return point;
    }
}
