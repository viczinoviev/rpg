using UnityEngine;

public class Player : MonoBehaviour
{
    private StateMachine stateMachine;

    public Player_IdleState IdleState { get; private set; }
    public Player_MoveState MoveState { get; private set; }

    private void Awake()
    {
        stateMachine = new StateMachine();

        IdleState = new Player_IdleState(this, stateMachine, "idle");
        MoveState = new Player_MoveState(this, stateMachine, "move");
    }

    private void Start()
    {
        stateMachine.Initialize(IdleState);
    }

    private void Update()
    {
        stateMachine.currentState.Update();
    }
}
