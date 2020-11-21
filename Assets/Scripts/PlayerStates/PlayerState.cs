using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerState
{
    protected Player player;
    protected PlayerAnimator playerAnimator;

    public abstract PlayerStateType stateType { get;}

    public virtual void Initialize(Player player)
    {
        this.player = player;
        playerAnimator = player.GetComponent<PlayerAnimator>();
    }

    public virtual void OnCollisionEnter(Collision2D collision) { }

    public abstract void OnEnter();
    public abstract void OnUpdate();
    public abstract void OnExit();
}

public enum PlayerStateType
{
    Idling = 0,
    Running = 1,
    Jumping = 2,
    Sitting = 3
}
