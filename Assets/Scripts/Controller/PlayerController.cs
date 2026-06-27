using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float climbSpeed = 4f;//Speed for climbing

    private PlayerPawn pawn;//The pawn controlled by this controller

    void Start()//Runs once
    {
        pawn = GetComponent<PlayerPawn>();//Gets PlayerPawn
    }

    void Update()//Runs every frame
    {
        float moveInput = Input.GetAxisRaw("Horizontal");//Gets A/D, arrows, or joystick left/right

        pawn.Move(moveInput);//Tells pawn to move

        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            pawn.Jump();//Tells pawn to jump
        }

        bool isDucking = Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow);//Checks duck input

        pawn.Duck(isDucking);//Tells pawn to duck

        float climbInput = Input.GetAxisRaw("Vertical");//Gets W/S, arrows, or joystick up/down

        if (Input.GetKey(KeyCode.LeftShift))//Temporary climb button for testing
        {
            pawn.Climb(climbInput, climbSpeed);//Tells pawn to climb
        }

        if (Input.GetKeyDown(KeyCode.Space))//Checks throw button
        {
            pawn.ThrowWeapon();//Tells pawn to throw weapon
        }
    }
}