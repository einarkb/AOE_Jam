using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskManager : MonoBehaviour
{
    [SerializeField]
    public List<Task> allTasks = new List<Task>();
    public Task activeTask;


    private Task GetRandomTask()
    {
        int count = allTasks.Count;
        if (count > 0)
        {

            return allTasks[Random.Range(0, count)];
        }
        return null;
    }

    public Task StartRandomTask()
    {
        Task t = GetRandomTask();
        if (t != null)
        {
            activeTask = t;
            t.StartTask();
            return t;
        }
        return null;
    }
}
