using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
public class AIMovement : Movement
{
    [SerializeField] AIDestinationSetter aIDestinationSetter;
    [SerializeField] AIPath aIPath;
    [SerializeField] Seeker seeker;
    [SerializeField] bool isStatic;
    [SerializeField] bool isRandom;
    [SerializeField] bool isRabbit;
    [SerializeField] float randomRadius;
    [SerializeField] Rigidbody2D rb;
    bool isJumping = false;
    private float _timer;
    [Range(0f, 1000f)]
    public float _time = 0.2f;
    public bool isTriggered;

    Vector3 pos;
    public GameObject target;
    protected override void Start()
    {
        base.Start();
        _timer = 0f;
    }
    public void setTarget()
    {
        target = GameObject.FindGameObjectWithTag("Player").gameObject;
        if (!isStatic && !isRandom)
        {
            aIDestinationSetter.target = target.transform;
            seeker.StartPath(transform.position, target.transform.position, OnPathComplete);
        }
        aIPath.canMove = true;
        aIPath.canSearch = true;
        isTriggered = true;
    }
    public void OnPathComplete(Path p)
    {
    }
    protected override void FixedUpdate()
    {
       
    }
    protected override void Update()
    {
        if (aIPath.hasPath)
        {
            animator.SetFloat("VelocityX", aIPath.desiredVelocity.normalized.x);
            animator.SetFloat("VelocityY", aIPath.desiredVelocity.normalized.y);
            if (isRandom)
            {
                if (!aIPath.pathPending && (aIPath.reachedEndOfPath || !aIPath.hasPath))
                {
                    aIPath.destination = RandomPathFromSphere(target, randomRadius);
                    aIPath.SearchPath();
                }
            }
            if (isRabbit)
            {

                _timer += Time.deltaTime;
                if (_timer >= _time && !isJumping)
                {
                    isJumping = true;
                    _timer = 0f;
                    StartCoroutine(Jump());
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
    }

    private Vector3 RandomPathFromSphere(GameObject player, float randomRadius)
    {
        Vector3 point = Random.insideUnitSphere * randomRadius;
        point.y = 0;
        point += player.transform.position;
        return point;
    }

    private IEnumerator Jump()
    {
        pos = target.transform.position;

     
        seeker.StartPath(transform.position, pos, OnPathComplete);

        aIPath.canMove = false;
        aIPath.canSearch = false;
        rb.velocity = Vector3.zero;
        rb.angularVelocity = 0;
        yield return new WaitForSeconds(0.5f);
        animator.Play("Idle");
    }

    public void StartPathing()
    {
        aIPath.canMove = true;
        aIPath.canSearch = true;

        isJumping = false;
    }

    public void DisableMovement()
    {
        aIPath.canSearch = false;
        aIPath.canMove = false;
        isTriggered = false;
    }

}
