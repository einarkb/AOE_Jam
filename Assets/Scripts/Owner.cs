using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Owner : MonoBehaviour
{
    public float taskDelay = 2f;

    public Transform throwFrom;

    private void OnEnable()
    {
        //Debug.Log(EventManager.Instance);
        EventManager.Instance.taskCompleted += (task) => StartNewTask(taskDelay);
        EventManager.Instance.taskFailed += (task) => GameOver();
        EventManager.Instance.onGameStart += () => StartGame();
    }

    private void OnDisable()
    {
        EventManager.Instance.taskCompleted -= (task) => StartNewTask(taskDelay);
        EventManager.Instance.taskFailed -= (task) => GameOver();
        EventManager.Instance.onGameStart -= () => StartGame();
    }

    private void StartNewTask(float delay)
    {
        StartCoroutine(StartTask(delay));
    }

    private IEnumerator StartTask(float delay)
    {
        yield return new WaitForSeconds(delay);
        GameManager.Instance.TaskManager.StartRandomTask();
    }

    private void GameOver()
    {
        EventManager.Instance.onGameover?.Invoke();
    }

    private void StartGame()
    {
        GameManager.Instance.ChatBubbleManager.OwnerSpeaking.ShowMessage("Time to train, Get ready!", 2f);
        StartNewTask(4f);
    }
}
