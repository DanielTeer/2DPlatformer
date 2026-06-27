using UnityEngine;

public class EnemyPawn : MonoBehaviour
{
    public float moveSpeed = 2f;//Speed of enemy

    public bool startsMovingRight = true;//Sets if enemy starts moving right

    public bool spriteFacesRight = true;//Set false if the sprite art faces left by default

    private Rigidbody2D rb;//Enemy Rigidbody

    private SpriteRenderer spriteRenderer;//Enemy SpriteRenderer

    private bool movingRight;//Tracks if enemy is moving right

    void Start()//Runs once
    {
        rb = GetComponent<Rigidbody2D>();//Gets Rigidbody

        spriteRenderer = GetComponent<SpriteRenderer>();//Gets SpriteRenderer

        movingRight = startsMovingRight;//Sets starting direction

        UpdateSpriteDirection();//Sets sprite direction at start
    }

    public void Move()//Moves enemy
    {
        if (movingRight)//Checks if enemy is moving right
        {
            rb.linearVelocity = new Vector2(moveSpeed, rb.linearVelocity.y);//Moves enemy right
        }
        else
        {
            rb.linearVelocity = new Vector2(-moveSpeed, rb.linearVelocity.y);//Moves enemy left
        }
    }

    public void TurnAround()//Turns enemy around
    {
        movingRight = !movingRight;//Switches direction

        UpdateSpriteDirection();//Updates sprite direction
    }

    void UpdateSpriteDirection()//Makes sprite face movement direction
    {
        if (spriteRenderer == null)//Checks if SpriteRenderer is missing
        {
            return;//Stops code
        }

        if (spriteFacesRight)//Checks if sprite art faces right by default
        {
            spriteRenderer.flipX = !movingRight;//Flips sprite when moving left
        }
        else
        {
            spriteRenderer.flipX = movingRight;//Flips sprite when moving right
        }
    }

    private void OnTriggerEnter2D(Collider2D other)//Runs when enemy enters a trigger
    {
        if (!other.CompareTag("EnemyBoundary"))//Checks if trigger is not an enemy boundary
        {
            return;//Stops code
        }

        TurnAround();//Turns enemy around
    }

    public void StopMovement()//Stops enemy movement
    {
        rb.linearVelocity = Vector2.zero;//Stops Rigidbody movement
    }
}