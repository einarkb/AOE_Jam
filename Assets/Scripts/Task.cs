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
    public string completePlayerThinking;

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
            Msg(startMessage, 2f);

        }
    }

    public void ObjectiveCompleted()
    {
        if (currentObjective + 1 >= count)
        {
            Msg(completeMessage, 2f);
            GameManager.Instance.ChatBubbleManager.PlayerThinking.ShowMessage(completePlayerThinking, 2f, 0.8f);
            EventManager.Instance.taskCompleted?.Invoke(this);

        }
        else
        {
            Objective o = GameManager.Instantiate(objectives[currentObjective]);
            o.StartObjective(this);
        }
    }

    public void ObjectiveFailed()
    {
   
        Msg(failedMessage, 2f);
        EventManager.Instance.taskFailed?.Invoke(this);
    }

    private void Msg(string text, float duration)
    {
        GameManager.Instance.ChatBubbleManager.OwnerSpeaking.ShowMessage(text, duration);
    }

}
