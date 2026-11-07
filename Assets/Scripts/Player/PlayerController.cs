using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public PlayerInputControl inputControl;
    private Rigidbody2D rb;
    private PhysicsCheck physicsCheck;
    private Animator anim;

    public Vector2 inputDirection;

    public PlayerAnimation playerAnimation;
    
    [Header("基本数值")]
    public float speed = 5f;
    public float jumpForce;
    public float runMultiplier = 3.0f;
    public float hurtForce;
    [Header("物理材质")]
    public PhysicsMaterial2D normal;
    public PhysicsMaterial2D wall;
    
    [Header("状态")]
    private bool isCtrlPressed = false;

    public bool isHurt;
    public bool isDead;
    public bool isAttack;
    
    
    

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        physicsCheck = GetComponent<PhysicsCheck>();

        playerAnimation = GetComponent<PlayerAnimation>();

       
        anim = GetComponent<Animator>();

        inputControl = new PlayerInputControl();
        inputControl.GamePlay.Jump.started += Jump;

        inputControl.GamePlay.Attact.started += PlayerAttack;

    }

    private void OnEnable() { inputControl.Enable(); }
    private void OnDisable() { inputControl.Disable(); }

    private void Update()
    {
        inputDirection = inputControl.GamePlay.Move.ReadValue<Vector2>();
        isCtrlPressed = Keyboard.current.leftShiftKey.isPressed || Keyboard.current.rightShiftKey.isPressed;

        SetAnimation();

    }

    public void SetAnimation()
    {

        anim.SetFloat("velocityX", Mathf.Abs(rb.linearVelocity.x));
    }

    private void FixedUpdate()
    {
        if (!isHurt)
            Move();
    }



    public void Move()
    {
        float currentSpeed = isCtrlPressed ? speed * runMultiplier : speed;
        rb.linearVelocity = new Vector2(inputDirection.x * currentSpeed, rb.linearVelocity.y);

      
        int faceDir = (int)transform.localScale.x;
        if (inputDirection.x > 0) faceDir = 10;
        if (inputDirection.x < 0) faceDir = -10;
        transform.localScale = new Vector3(faceDir, 10, 10);
    }

    private void Jump(InputAction.CallbackContext context)
    {
        if (physicsCheck.isGround)
        {
            rb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
        }
    }

    private void PlayerAttack(InputAction.CallbackContext obj)
    {
        playerAnimation.PlayAttack();
        isAttack = true;
      
    }


    #region UnityEvent
    public void GetHurt(Transform attacker)
    {
        isHurt = true;
        rb.linearVelocity = Vector2.zero;
        Vector2 dir = new Vector2((transform.position.x - attacker.position.x), 0).normalized;

        rb.AddForce(dir * hurtForce, ForceMode2D.Impulse);
    }

    public void PlayerDead()
    {
        isDead = true;
        inputControl.GamePlay.Disable();
    }
    #endregion

    
}