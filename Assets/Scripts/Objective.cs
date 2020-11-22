using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objective: MonoBehaviour
{
    Task task;


    public virtual void StartObjective(Task task = null) { this.task = task; }

    protected void ObjectiveCompleted() 
    { 
        task?.ObjectiveCompleted(); 
    }

    protected void ObjectiveFailed()
    {
        task?.ObjectiveFailed();
    }


}
