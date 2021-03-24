using UnityEngine;

public class PlayerAnimationScript : MonoBehaviour
{
    [SerializeField]

    private Animator animator;

    private float xAxis;
    private float zAxis;
    public GameObject camTarget;
    public GameObject paladinTarget;
    public Vector3 camPosition;
    public Vector3 paladinPosition;
    private Rigidbody rbd;
    public Vector3 deltaMove;
    private bool isGrounded = false;
    public string currentState;
    private bool isAttacking = false;
    private bool isAttackPressed = false;
    private bool isBlockPressed = false;
    private bool isCrouch = false;
    private bool isJumpPressed = false;
    private bool isJumping = false;
    private bool isRollPressed = false;
    private bool isRolling = false;
    private bool isRunPressed = false;
    private bool isMoving = false;

    [SerializeField]
    private float actionDelay = 0.7f;




    // Start is called before the first frame update
    void Start()
    {
        rbd = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        //Check Inputs
        xAxis = Input.GetAxisRaw("Horizontal");
        zAxis = Input.GetAxisRaw("Vertical");

        //-------------------------------------

        //Left click to Basic Attack
        if (Input.GetMouseButtonDown(0)) isAttackPressed = true;
        //Space to jump
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded) isJumpPressed = true;
        // X to roll
        if (Input.GetKeyDown(KeyCode.X)) isRollPressed = true;
        //right click to be on block mode
        if (Input.GetMouseButton(1)) isBlockPressed = true;
        else isBlockPressed = false;
        //Shift to change to run
        if (Input.GetKey(KeyCode.LeftShift)) isRunPressed = true;
        else isRunPressed = false;
        //Ctrl to crouch
        if (Input.GetKey(KeyCode.LeftControl)) isCrouch = true;
        else isCrouch = false;
    }

    private void FixedUpdate()
    {
        //Is the player moving with WASD?
        isMoving = xAxis != 0 || zAxis != 0;
        // If he is attacking or jumping, stop
        if (isAttacking) return; 
        if (isJumping) return;
        if (isRolling) return;
        // Walk or Run
        if (xAxis == 0 && zAxis == 0 )
        {
            ChangeAnimationState(ActListConst.Idle);
        }
        else //if (isMoving)
        {
            isAttacking = false;
            if (!isRunPressed)
            {
                ChangeAnimationState(ActListConst.Walking); 
            }
            else
            {
                deltaMove = new Vector3(xAxis, 0, zAxis) * Time.deltaTime*2;
                ChangeAnimationState(ActListConst.Running);
                transform.parent.Translate(deltaMove);
            }
        }

        //-------------------------------------

        //If he can jump, then lock jump till he finishes
        if (isJumpPressed && isGrounded && !isJumping)
        {
            isJumpPressed = false;
            isJumping = true;
            if (isMoving)
            {
                ChangeAnimationState(ActListConst.MovingJump);
            }
            else 
            {
                ChangeAnimationState(ActListConst.IdleJump);
            }
            actionDelay = animator.GetCurrentAnimatorStateInfo(0).length;
            Invoke("JumpComplete", actionDelay);
            rbd.velocity =new Vector3(0, 5, 0);
        }

        //-------------------------------------

        //If he can roll, then lock roll till he finishes
        if (isRollPressed && isGrounded && !isRolling)
        {
            isRollPressed = false;
            isRolling = true;
            ChangeAnimationState(ActListConst.Roll);
            if (zAxis > 0 && isRunPressed)
            {
                deltaMove = new Vector3(xAxis, 0, zAxis) * Time.deltaTime*3;
            }
            else if (zAxis > 0)
            {
                deltaMove = new Vector3(xAxis, 0, zAxis) * Time.deltaTime*2;
            }
            transform.parent.Translate(deltaMove);
            actionDelay = animator.GetCurrentAnimatorStateInfo(0).length;
            Invoke("RollComplete", actionDelay);
        }

        //----------------------------------

        //If he can attack, then he will
        if (isAttackPressed && !isAttacking) 
        {
                isAttackPressed = false;
                isAttacking = true;
                if (isGrounded)
                {
                    ChangeAnimationState(ActListConst.Slash);
                }
                else
                {
                    ChangeAnimationState(ActListConst.JumpAttack);
                }
                actionDelay = animator.GetCurrentAnimatorStateInfo(0).length ;

                Invoke("AttackComplete", actionDelay);
        }

    }

    private void AttackComplete() 
    {
        isAttacking = false;
    }
    private void JumpComplete()
    {
        isJumping = false;
        rbd.velocity = new Vector3(0,0,0);
    }
    private void RollComplete()
    {
        isRolling = false;
    }
    private void ChangeAnimationState(string newState)
    {
        animator.SetFloat("y", zAxis);   //y is moving forward, zAxis is the value assigned to the task
        animator.SetFloat("x", xAxis);   //y is moving forward, zAxis is the value assigned to the task
        //Stop same animation from interrupting itself
        if (this.currentState == newState) return;
        animator.StopPlayback();
        //Play animation
        animator.PlayInFixedTime(newState);
        //print("animation played" + xAxis + " " + zAxis + " " + newState);

        //reassign the current state
        currentState = newState;

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "floor")
        {
            isGrounded = true;
        }
        else 
        {
            isGrounded = false;
        }
        if (collision.collider.tag != "floor")
        {
            camPosition = camTarget.transform.position;
            paladinPosition = paladinTarget.transform.position;
            
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.tag == "floor")
        {
            isGrounded = false;
        }
        if (collision.collider.tag != "floor")
        {
            Vector3 distance = new Vector3(paladinTarget.transform.position.x - paladinPosition.x, paladinTarget.transform.position.y - paladinPosition.y, paladinTarget.transform.position.z - paladinPosition.z);


            print("cam: " + camPosition + " current: " + camTarget.transform.position);
            print("Player: " + paladinPosition + "Player: " + paladinTarget.transform.position + "  distance   " + distance);
            
            
            camTarget.transform.position = new Vector3(camPosition.x + distance.x, camPosition.y + distance.y, camPosition.z + distance.z);

        }
    }
}

    
public static class ActListConst //List of all action Names of Animation States
{
    public const string
        BlockIdle = "BlockIdle",
        CrouchDown = "CrouchDown",
        CrouchGetUp = "CrouchGetUp",
        CrouchIdle = "CrouchIdle",
        Idle = "Idle",
        IdleJump = "IdleJump",
        JumpAttack = "JumpAttack",
        MovingJump = "MovingJump",
        Running = "Running",
        Walking = "Walking",
        Slash = "Slash",
        Roll = "Roll"
        ;
}