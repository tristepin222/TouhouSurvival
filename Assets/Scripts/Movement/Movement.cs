using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    //private serializefield vars
    [SerializeField] private new Rigidbody2D rigidbody2D;
    [SerializeField] private Animator animator;
    [SerializeField] private float speed = 1f;
    [SerializeField] private float animatorSpeedRatio = 2f;

    //private vars
    private Vector2 movement;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //get input
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate()
    {
        //set animator global speed
        animator.speed = speed / animatorSpeedRatio;
        //set animator velocity vars
        animator.SetFloat("VelocityX", movement.x);
        animator.SetFloat("VelocityY", movement.y);

        //move the rigidbody
        rigidbody2D.MovePosition(rigidbody2D.position + movement * speed * Time.fixedDeltaTime);
    }
}
