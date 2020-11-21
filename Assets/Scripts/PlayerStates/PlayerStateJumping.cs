using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateJumping : PlayerState
{

    [SerializeField]
    private float jumpPower = 12f;

    [SerializeField]
    private float jumpHorizontalSpeed = 4f;


    private Rigidbody2D rb;

    public override void Initialize(Player player)
    {
        base.Initialize(player);
        rb = player.GetComponent<Rigidbody2D>();
    }

    public override PlayerStateType stateType { get => PlayerStateType.Jumping; }

    public override void OnEnter()
    {
        playerAnimator.Anim.SetBool("Jumping", true);
        Debug.Log("Jumping entered");
        rb.velocity = new Vector2(rb.velocity.x, jumpPower);
    }

    public override void OnExit()
    {
        playerAnimator.Anim.SetBool("Jumping", false);
    }

    public override void OnUpdate() 
    { 
        if (player.IsInputAllowed)
        {
            rb.velocity = new Vector2(Input.GetAxis("Horizontal") * jumpHorizontalSpeed, rb.velocity.y);
        }

        playerAnimator.Anim.SetFloat("VelocityY", rb.velocity.y);
        playerAnimator.Anim.SetFloat("VelocityX", Mathf.Abs(rb.velocity.x) / jumpHorizontalSpeed);
    }

    public override void OnCollisionEnter(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            if (Input.GetAxis("Horizontal") != 0f)
            {
                player.ChangeState(PlayerStateType.Running);
            }
            else
            {
                player.ChangeState(PlayerStateType.Idling);
            }
            
        }
    }

}
