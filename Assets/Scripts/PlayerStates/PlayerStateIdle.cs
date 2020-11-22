using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateIdle : PlayerState
{

    public override PlayerStateType stateType { get => PlayerStateType.Idling; }

    public override void OnEnter()
    {
        playerAnimator.Anim.SetBool("Standing", true);
        //Debug.Log("Idle entered");
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

            else if (Input.GetAxis("Horizontal") != 0f)
            {
                player.ChangeState(PlayerStateType.Running);
            }

            else if (Input.GetKey(KeyCode.S))
            {
                player.ChangeState(PlayerStateType.Sitting);
            }

        }
    }
}


