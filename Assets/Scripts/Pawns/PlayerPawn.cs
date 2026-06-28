using UnityEngine;

public class PlayerPawn : MonoBehaviour
{
    public float moveSpeed = 6f;//Speed of player

    public float jumpForce = 12f;//Jump strength

    public Transform groundCheck;//Empty object at the players feet

    public float groundCheckRadius = 0.2f;//Size of the ground check

    public LayerMask groundLayer;//The layer that counts as ground

    public Transform throwPoint;//Empty object where weapon spawns from

    public GameObject weaponPrefab;//Weapon prefab the player throws

    public float throwForce = 10f;//Speed of thrown weapon

    private Rigidbody2D rb;//The players Rigidbody

    private Animator animator;//The players Animator

    private SpriteRenderer spriteRenderer;//The players SpriteRenderer

    private bool isGrounded;//Tracks if the player is touching ground

    private bool facingRight = true;//Tracks which way the player is facing

    void Start()//Runs once
    {
        rb = GetComponent<Rigidbody2D>();//Gets the Rigidbody

        animator = GetComponent<Animator>();//Gets the Animator

        spriteRenderer = GetComponent<SpriteRenderer>();//Gets the SpriteRenderer
    }

    void Update()//Runs every frame
    {
        CheckGrounded();//Updates whether the player is grounded
    }

    public void Move(float direction)//Moves the player pawn
    {
        rb.linearVelocity = new Vector2(direction * moveSpeed, rb.linearVelocity.y);//Sets horizontal speed

        if (direction > 0)//Checks if player is moving right
        {
            facingRight = true;//Stores facing right

            spriteRenderer.flipX = false;//Faces sprite right
        }
        else if (direction < 0)//Checks if player is moving left
        {
            facingRight = false;//Stores facing left

            spriteRenderer.flipX = true;//Faces sprite left
        }

        if (animator != null)//Checks if there is an Animator
        {
            animator.SetFloat("Speed", Mathf.Abs(direction));//Sends speed to Animator
        }
    }

    public void Jump()//Makes player jump
    {
        if (isGrounded)//Only jumps if player is grounded
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);//Sets jump velocity

            if (AudioManager.Instance != null)//Checks if AudioManager exists
            {
                AudioManager.Instance.PlayJump();//Plays jump sound
            }
        }
    }

    public void Duck(bool isDucking)//Makes player duck
    {
        if (animator != null)//Checks if there is an Animator
        {
            animator.SetBool("IsDucking", isDucking);//Sends duck value to Animator
        }
    }

    public void Climb(float climbInput, float climbSpeed)//Moves player up or down while climbing
    {
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, climbInput * climbSpeed);//Sets vertical climbing speed

        if (animator != null)//Checks if there is an Animator
        {
            animator.SetBool("IsClimbing", Mathf.Abs(climbInput) > 0);//Tells Animator if player is climbing
        }
    }

    public void ThrowWeapon()//Throws a weapon
    {
        if (weaponPrefab == null)//Checks if weapon prefab is missing
        {
            return;//Stops code
        }

        if (throwPoint == null)//Checks if throw point is missing
        {
            return;//Stops code
        }

        GameObject weapon = Instantiate(weaponPrefab, throwPoint.position, Quaternion.identity);//Spawns weapon

        Rigidbody2D weaponRb = weapon.GetComponent<Rigidbody2D>();//Gets weapon Rigidbody

        if (weaponRb != null)//Checks if weapon has Rigidbody
        {
            if (facingRight)//Checks if player is facing right
            {
                weaponRb.AddForce(Vector2.right * throwForce, ForceMode2D.Impulse);//Throws weapon right with force
            }
            else
            {
                weaponRb.AddForce(Vector2.left * throwForce, ForceMode2D.Impulse);//Throws weapon left with force
            }
        }

        if (animator != null)//Checks if there is an Animator
        {
            animator.SetTrigger("Throw");//Plays throw animation
        }
    }

    public void HurtAnimation()//Plays player hurt animation
    {
        if (animator != null)//Checks if there is an Animator
        {
            animator.SetTrigger("Hurt");//Triggers hurt animation
        }
    }

    public void StopMovement()//Stops player movement
    {
        rb.linearVelocity = Vector2.zero;//Stops all Rigidbody movement
    }

    void CheckGrounded()//Checks if player is touching ground
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);//Checks for ground under feet

        if (animator != null)//Checks if there is an Animator
        {
            animator.SetBool("IsGrounded", isGrounded);//Sends grounded value to Animator
        }
    }

    public bool GetIsGrounded()//Lets other scripts check if player is grounded
    {
        return isGrounded;//Returns grounded value
    }
}