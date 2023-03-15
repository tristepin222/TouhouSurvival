using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;
public class Movement : MonoBehaviour
{
    //private serializefield vars
    [SerializeField] private new Rigidbody2D rigidbody2D;
    [SerializeField] private float speed = 2f;
    [SerializeField] private float animatorSpeedRatio = 2f;

    [SerializeField] protected Animator animator;
    [SerializeField] protected VisualEffect walkEffect;
    //private vars
    private Vector2 movement;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        //get input
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
    }

    protected virtual void FixedUpdate()
    {
        //set animator global speed
        animator.speed = speed / animatorSpeedRatio;
        //set animator velocity vars
        animator.SetFloat("VelocityX", movement.x);
        animator.SetFloat("VelocityY", movement.y);

        //move the rigidbody
        rigidbody2D.MovePosition(rigidbody2D.position + movement * speed * Time.fixedDeltaTime);

        //test if movement is 0
        if (!movement.Equals(Vector2.zero))
        {
            walkEffect.Stop();
        }
        else
        {
            walkEffect.SendEvent("Play");
        }
    }
}
