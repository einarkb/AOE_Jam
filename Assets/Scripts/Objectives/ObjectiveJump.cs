using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveJump : Objective
{
    [SerializeField]
    private float timeLimit = 3f;

    private float objectiveTimeLeft;
    private bool active = false;

    private float cd = 0f;

    public override void StartObjective(Task task = null)
    {
        if (GameManager.Instance.Player.CurrentState.stateType == PlayerStateType.Jumping)
        {
            cd = 1f;
        }
    
        base.StartObjective(task);
        objectiveTimeLeft = timeLimit;
    }



    private void Update()
    {
        if (GameManager.Instance.Player.CurrentState.stateType == PlayerStateType.Jumping && cd <= 0f)
        {
            Debug.Log(cd);
            base.ObjectiveCompleted();
            Destroy(gameObject);
            return;
        }

        cd -= Time.deltaTime;

        if (timeLimit > 0f)
        {
            objectiveTimeLeft -= Time.deltaTime;
            if (objectiveTimeLeft <= 0f)
            {
                base.ObjectiveFailed();
                Destroy(this.gameObject);
            }
        }
    }
}
