using UnityEngine;

public abstract class EntityState
{
    protected Player player;
    protected StateMachine stateMachine;
    protected string stateName;

    public EntityState(Player player, StateMachine stateMachine, string stateName)
    {
        this.player = player;
        this.stateMachine = stateMachine;
        this.stateName = stateName;
    }

    public virtual void Enter() 
    {
        // Enter will be called every time we enter a state
        Debug.Log("Entering state: " + stateName);
    }

    public virtual void Update()
    {
        // Update will run the logic of the state
        Debug.Log("Updating state: " + stateName);
    }

    public virtual void Exit() 
    {
        // Exit will be called every time we exit a state
        Debug.Log("Exiting state: " + stateName);
    }
}
