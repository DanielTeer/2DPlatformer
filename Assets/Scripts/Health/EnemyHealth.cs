using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 2;//Most health enemy can have

    public float destroyDelay = 1f;//Time before enemy is destroyed after death

    private int currentHealth;//Current enemy health

    private Animator animator;//Enemy Animator

    private Rigidbody2D rb;//Enemy Rigidbody

    private EnemyController enemyController;//Enemy controller

    private EnemyPawn enemyPawn;//Enemy pawn

    private DamageOnTouch damageOnTouch;//Enemy damage script

    private bool isDead;//Tracks if enemy already died

    void Start()//Runs once
    {
        currentHealth = maxHealth;//Starts enemy at full health

        animator = GetComponent<Animator>();//Gets Animator

        rb = GetComponent<Rigidbody2D>();//Gets Rigidbody

        enemyController = GetComponent<EnemyController>();//Gets EnemyController

        enemyPawn = GetComponent<EnemyPawn>();//Gets EnemyPawn

        damageOnTouch = GetComponent<DamageOnTouch>();//Gets DamageOnTouch
    }

    public void TakeDamage(int damageAmount)//Damages enemy
    {
        if (isDead)//Checks if enemy is already dead
        {
            return;//Stops code
        }

        currentHealth -= damageAmount;//Subtracts enemy health

        if (currentHealth <= 0)//Checks if enemy health is gone
        {
            Die();//Kills enemy
        }
        else
        {
            Hurt();//Plays hurt animation if enemy survived
        }
    }

    void Hurt()//Runs when enemy is damaged but not dead
    {
        if (animator != null)//Checks if Animator exists
        {
            animator.SetTrigger("Hit");//Plays enemy hit animation
        }
    }

    void Die()//Runs when enemy dies
    {
        isDead = true;//Marks enemy as dead

        if (enemyController != null)//Checks if controller exists
        {
            enemyController.enabled = false;//Stops enemy controller
        }

        if (enemyPawn != null)//Checks if pawn exists
        {
            enemyPawn.StopMovement();//Stops enemy movement
        }

        if (damageOnTouch != null)//Checks if damage script exists
        {
            damageOnTouch.enabled = false;//Stops enemy from hurting player
        }

        if (rb != null)//Checks if Rigidbody exists
        {
            rb.linearVelocity = Vector2.zero;//Stops Rigidbody movement

            rb.gravityScale = 0f;//Stops enemy from falling

            rb.bodyType = RigidbodyType2D.Kinematic;//Freezes enemy physics
        }

        if (animator != null)//Checks if Animator exists
        {
            animator.SetTrigger("Die");//Plays enemy death animation
        }

        Destroy(gameObject, destroyDelay);//Destroys enemy after delay
    }
}