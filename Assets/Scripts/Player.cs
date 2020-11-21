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

    public float faceDir { get; private set; } = 1f;

    public bool IsInputAllowed { get; set; } = true;

    private Rigidbody2D rb;

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

        if (rb.velocity.x > 0.1f)
        {
            faceDir = 1;
            EventManager.Instance.playerFacingDirectionChanged?.Invoke(1);
        }
        else if (rb.velocity.x < -0.1f)
        {
            EventManager.Instance.playerFacingDirectionChanged?.Invoke(-1);
            faceDir = -1;
        }
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

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
