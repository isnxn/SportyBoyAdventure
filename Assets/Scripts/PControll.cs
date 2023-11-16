using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PControll : MonoBehaviour
{
    
    private Animator anim;
    private Rigidbody2D rb;
    private float directionX;
    private SpriteRenderer sprite;
    private BoxCollider2D coll;
    private enum MovementState {Idle,Running,Jump,Fall,Hit}
    public LayerMask jumpableGround;
    public AudioSource JumpSoundFX;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        coll = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        directionX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(directionX * 5f, rb.velocity.y);

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            JumpSoundFX.Play();
            rb.velocity = new Vector2(rb.velocity.x,10f);
        }

        UpdateAnimationState();
    }
    
     private void UpdateAnimationState()
    {
        MovementState state;

        if (directionX > 0f)
        {
            state = MovementState.Running;
            sprite.flipX = false;

        }
        else if (directionX <0f)
        {
            state = MovementState.Running;
            sprite.flipX = true;
        }
        else
        {
             state = MovementState.Idle;
        }

        if (rb.velocity.y > .1f)
        {
            state = MovementState.Jump;
        }
        else if (rb.velocity.y < -.1f)
        {
            state = MovementState.Fall;
        }

        anim.SetInteger("state",(int)state);
    }

    private bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }
}