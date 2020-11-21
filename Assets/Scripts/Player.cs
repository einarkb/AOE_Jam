using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Dictionary<PlayerStateType, PlayerState> PlayerStates { get; private set; }
    [SerializeField]
    public List<PlayerState> pStates;

    [SerializeField]
    private PlayerStateType startingState;

    [SerializeField]
    private PlayerState currentState;

    public PlayerState CurrentState
    {
        get => currentState;
        private set => currentState = value;
    }

    public bool IsInputAllowed { get; set; } = true;

    public void ChangeState(PlayerStateType stateType)
    {
        if (PlayerStates.ContainsKey(stateType))
        {
            currentState?.OnExit();
            currentState = PlayerStates[stateType];
            currentState.OnEnter();
        }
    }

    private void Update()
    {
        currentState?.OnUpdate();
    }

    private void Awake()
    {
        PlayerStates = new Dictionary<PlayerStateType, PlayerState>();

        PlayerStates.Add(PlayerStateType.Idling, new PlayerStateIdle());
        PlayerStates.Add(PlayerStateType.Running, new PlayerStateRunning());
        PlayerStates.Add(PlayerStateType.Jumping, new PlayerStateJumping());
        PlayerStates.Add(PlayerStateType.Sitting, new PlayerStateSitting());

        foreach (PlayerState state in PlayerStates.Values)
        {
            state.Initialize(this);
        }
    }


    private void Start()
    {
        ChangeState(startingState);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        currentState?.OnCollisionEnter(collision);
    }

}
