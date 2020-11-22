using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Owner : MonoBehaviour
{
    public float taskDelay = 2f;

    private void Start()
    {
        StartCoroutine(StartTask());
    }

    private void OnEnable()
    {
        Debug.Log(EventManager.Instance);
        EventManager.Instance.taskCompleted += (task) => StartNewTask();
        EventManager.Instance.taskFailed += (task) => StartNewTask();
    }

    private void OnDisable()
    {
        EventManager.Instance.taskCompleted -= (task) => StartNewTask();
        EventManager.Instance.taskFailed -= (task) => StartNewTask();
    }

    private void StartNewTask()
    {
        StartCoroutine(StartTask());
    }

    private IEnumerator StartTask()
    {
        yield return new WaitForSeconds(taskDelay);
        GameManager.Instance.TaskManager.StartRandomTask();
    }
}
