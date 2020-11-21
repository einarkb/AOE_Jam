﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateSitting : PlayerState
{

    public override PlayerStateType stateType { get => PlayerStateType.Sitting; }


    public override void OnEnter()
    {
        playerAnimator.Anim.SetBool("Sitting", true);
        Debug.Log("Sitting entered");
    }

    public override void OnExit()
    {
        playerAnimator.Anim.SetBool("Sitting", false);
    }

    public override void OnUpdate()
    {
        if (player.IsInputAllowed)
        {
            if (!Input.GetKey(KeyCode.S))
            {
                player.ChangeState(PlayerStateType.Idling);
            }
        }
    }

}
