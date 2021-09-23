using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovemant : MonoBehaviour
{
    private Rigidbody2D rbody;
    private BoxCollider2D boxColl;
    private SpriteRenderer sprite;
    private Animator anim;
    

    [SerializeField] private LayerMask jumpableGround;


    private float xAxis = 0f;
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float jumpForce = 14f;

    private enum MovementState { idle, running, jumping, falling };

    [SerializeField] private AudioSource jumpingSound;
    

    // Start is called before the first frame update
    private void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        boxColl = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        xAxis = Input.GetAxisRaw("Horizontal");
        rbody.velocity = new Vector2(xAxis * moveSpeed, rbody.velocity.y);

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            jumpingSound.Play();
            rbody.velocity = new Vector3(rbody.velocity.x, jumpForce, 0);
        }


        UpdateAnimationState();
        
    }

    private void UpdateAnimationState()
    {
        MovementState state; 

        if (xAxis > 0f)
        {
            state = MovementState.running;
            sprite.flipX = false;
        }
        else if (xAxis < 0f)
        {
            state = MovementState.running;
            sprite.flipX = true;
        }
        else
        {
            state = MovementState.idle;
        }

        if(rbody.velocity.y > .1f)
        {
            state = MovementState.jumping;
        }
        else if (rbody.velocity.y < -.1f)
        {
            state = MovementState.falling;
        }
        anim.SetInteger("state", (int)state);
    }

    private bool IsGrounded()
    {
        return Physics2D.BoxCast(boxColl.bounds.center, boxColl.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }
}
