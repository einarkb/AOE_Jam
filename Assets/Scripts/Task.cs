using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Task
{
    public List<Objective> objectives = new List<Objective>();
    public string startMessage;
    public string completeMessage;
    public string failedMessage;

    [HideInInspector]
    public int currentObjective = -1;

    private int count = 0;


    public void StartTask()
    {
        count = objectives.Count;
        currentObjective = count - 1;
        if (currentObjective >= 0)
        {
            Objective o = GameManager.Instantiate(objectives[currentObjective]);
            o.StartObjective(this);
        }
    }

    public void ObjectiveCompleted()
    {
        if (currentObjective + 1 >= count)
        {
            Debug.Log("Task Completed");
        }
        else
        {
            Objective o = GameManager.Instantiate(objectives[currentObjective]);
            o.StartObjective(this);
        }
    }

    public void ObjectiveFailed()
    {
        Debug.Log("Task Failed");
    }


}
