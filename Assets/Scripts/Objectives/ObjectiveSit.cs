using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveSit : Objective
{
    [SerializeField]
    private float timeLimit = 3f;
    [SerializeField]
    private float timeToSit = 3f;
    [SerializeField]
    private Collider2D SittingAreaTrigger;

    private bool isActive = false;
    private float sitLeft;
    private float objectiveTimeLeft;
    

    public override void StartObjective(Task task = null)
    {
        base.StartObjective(task);
        sitLeft = timeToSit;
        objectiveTimeLeft = timeLimit;
        isActive = true;
    }

    private void Update()
    {
    

        if (isActive)
        {
            bool isSitting = GameManager.Instance.Player.CurrentState.stateType == PlayerStateType.Sitting;
            if (isSitting)
            {
                if (SittingAreaTrigger == null || SittingAreaTrigger.IsTouchingLayers(1 << LayerMask.NameToLayer("Player")))
                {
                    sitLeft -= Time.deltaTime;
                    if (sitLeft <= 0f)
                    {
                        Debug.Log("goalComplete");
                        isActive = false;
                        base.ObjectiveCompleted();
                        Destroy(this);

                        return;
                    }
                }
            }
            else
            {
                sitLeft = timeToSit;
            }

            if (timeLimit > 0f)
            {
                objectiveTimeLeft -= Time.deltaTime;
                if (objectiveTimeLeft <= 0f)
                {
                    Debug.Log("Failed");
                    base.ObjectiveFailed();
                    Destroy(this);
                }
            }

        }
    }
}
