﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateRunning : PlayerState
{
    [SerializeField]
    private float maxRunSpeed = 6f;


    private Rigidbody2D rb;

    public override void Initialize(Player player)
    {
        base.Initialize(player);
        rb = player.GetComponent<Rigidbody2D>();
    }

    public override PlayerStateType stateType { get => PlayerStateType.Running; }

    public override void OnEnter()
    {
        playerAnimator.Anim.SetBool("Standing", true);
        //Debug.Log("Running entered");
    }

    public override void OnExit()
    {
        playerAnimator.Anim.SetBool("Standing", false);
    }

    public override void OnUpdate()
    {
        if (player.IsInputAllowed)
        {

            if (Input.GetKeyDown(KeyCode.Space))
            {
                player.ChangeState(PlayerStateType.Jumping);
            }

            else
            {


                rb.velocity = new Vector2(Input.GetAxis("Horizontal") * maxRunSpeed, rb.velocity.y);

                if (rb.velocity.x == 0f)
                {
                    player.ChangeState(PlayerStateType.Idling);
                }
            }
        }

        playerAnimator.Anim.SetFloat("VelocityX", Mathf.Abs(rb.velocity.x) / maxRunSpeed);


    }
}
