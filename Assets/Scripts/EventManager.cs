using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public static EventManager Instance { get; set; }


    public delegate void PlayerFacingDirectionChanged(float dir);
    public PlayerFacingDirectionChanged playerFacingDirectionChanged;

    public delegate void TaskCompleted(Task task);
    public TaskCompleted taskCompleted;

    public delegate void TaskFailed(Task task);
    public TaskFailed taskFailed;

    public delegate void OnGameStart();
    public OnGameStart onGameStart;

    public delegate void OnGameOver();
    public OnGameOver onGameover;

    public delegate void PlayerStateChanged(PlayerStateType stateType);
    public PlayerStateChanged playerStateChanged;


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        //Debug.Log(EventManager.Instance);
    }
}
