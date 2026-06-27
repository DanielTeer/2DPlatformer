using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour
{
    public int maxHealth = 3;//Most health this object can have

    public int currentHealth;//Current health during gameplay

    public float invincibleTime = 1f;//Time player cannot take damage after getting hurt

    private bool isInvincible;//Tracks if damage should be ignored

    private PlayerPawn playerPawn;//The PlayerPawn script if this is the player

    void Start()//Runs once
    {
        currentHealth = maxHealth;//Starts at full health

        playerPawn = GetComponent<PlayerPawn>();//Gets PlayerPawn if this object has one

        GameManager.instance.UpdateHealthUI(currentHealth, maxHealth);//Updates health UI
    }

    public void TakeDamage(int damageAmount)//Takes damage
    {
        if (isInvincible)//Checks if object is invincible
        {
            return;//Stops code
        }

        currentHealth -= damageAmount;//Subtracts health

        if (CompareTag("Player") && AudioManager.Instance != null)//Checks if player and AudioManager exists
        {
            AudioManager.Instance.PlayHurt();//Plays hurt sound
        }

        if (playerPawn != null)//Checks if this is the player
        {
            playerPawn.HurtAnimation();//Plays hurt animation
        }

        GameManager.instance.UpdateHealthUI(currentHealth, maxHealth);//Updates health UI

        if (currentHealth <= 0)//Checks if health is gone
        {
            Die();//Runs death code
        }
        else
        {
            StartCoroutine(InvincibilityTimer());//Starts invincibility
        }
    }

    public void HealFull()//Restores health
    {
        currentHealth = maxHealth;//Sets health to max

        GameManager.instance.UpdateHealthUI(currentHealth, maxHealth);//Updates health UI
    }

    void Die()//Runs when health reaches zero
    {
        if (CompareTag("Player"))//Checks if this object is the player
        {
            GameManager.instance.PlayerLostLife();//Tells GameManager player lost a life
        }
        else
        {
            Destroy(gameObject);//Destroys non-player object
        }
    }

    IEnumerator InvincibilityTimer()//Runs invincibility timer
    {
        isInvincible = true;//Turns invincible on

        yield return new WaitForSeconds(invincibleTime);//Waits

        isInvincible = false;//Turns invincible off
    }
}