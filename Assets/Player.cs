using UnityEditorInternal;
using UnityEngine;
using UnityEngine.Networking;

public class Player : MonoBehaviour
{
    public Animator anim { get; private set; }

    public Rigidbody2D rb { get; private set; }

    public PlayerInputSet input { get; private set; }
    private StateMachine stateMachine;

    public Player_IdleState IdleState { get; private set; }
    public Player_MoveState MoveState { get; private set; }
    public Player_JumpState JumpState { get; private set; }
    public Player_FallState FallState { get; private set; }

    [Header("Movement Details")]
    public float moveSpeed;
    public float jumpForce = 5;
    public Vector2 moveInput { get; private set; }

    private bool isFacingRight = true;

    private void Awake()
    {
        anim = GetComponentInChildren<Animator>();

        rb = GetComponent<Rigidbody2D>();

        input = new PlayerInputSet();

        stateMachine = new StateMachine();

        IdleState = new Player_IdleState(this, stateMachine, "idle");
        MoveState = new Player_MoveState(this, stateMachine, "move");
        JumpState = new Player_JumpState(this, stateMachine, "jumpFall");
        FallState = new Player_FallState(this, stateMachine, "jumpFall");
    }

    private void OnEnable()
    {
        input.Enable();

        input.Player.Movement.performed += ctx => moveInput = ctx.ReadValue<Vector2>();
        input.Player.Movement.canceled += ctx => moveInput = Vector2.zero;
    }

    private void OnDisable()
    {
        input.Disable();
    }

    private void Start()
    {
        stateMachine.Initialize(IdleState);
    }

    private void Update()
    {
        stateMachine.UpdateActiveState();
        anim.SetFloat("yVelocity", rb.linearVelocity.y);
    }

    public void SetVelocity(float xVelocity, float yVelocity)
    {
        rb.linearVelocity = new Vector2(xVelocity, yVelocity);
        HandleFlip(xVelocity);
    }

    private void HandleFlip(float xVelocity)
    {
        if (isFacingRight && xVelocity < 0)
            Flip();
        else if (!isFacingRight && xVelocity > 0)
            Flip();
    }

    private void Flip()
    {
        transform.Rotate(0f, 180f, 0);
        isFacingRight = !isFacingRight;
    }
}
