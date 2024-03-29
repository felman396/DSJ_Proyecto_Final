using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main_character : MonoBehaviour
{
    public float velocity;
    private Rigidbody2D rigidbody;
    private bool lookingRight = true;
    private Animator animator;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessMovement();
    }

    void ProcessMovement()
    {
        // Movement
        float inputMovement = Input.GetAxis("Horizontal");
   
        if(inputMovement != 0f)
        {
            animator.SetBool("isRunning", true);
        }
        else
        {
            animator.SetBool("isRunning", false);
        }

        rigidbody.velocity = new Vector2(inputMovement * velocity, rigidbody.velocity.y);
        ManageOrientation(inputMovement);
    }

    void ManageOrientation(float inputMovement)
    {
        //
        if((lookingRight == true && inputMovement < 0) || (lookingRight == false && inputMovement > 0))
        {
            lookingRight = !lookingRight;
            transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
        }
    }

}
