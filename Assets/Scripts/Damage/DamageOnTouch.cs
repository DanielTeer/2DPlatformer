using UnityEngine;

public class DamageOnTouch : MonoBehaviour
{
    public int damageAmount = 1;//Damage amount given to player

    private void OnCollisionEnter2D(Collision2D collision)//Runs on collision
    {
        Damage(collision.gameObject);//Tries to damage object
    }

    private void OnTriggerEnter2D(Collider2D other)//Runs on trigger
    {
        Damage(other.gameObject);//Tries to damage object
    }

    void Damage(GameObject objectToDamage)//Damages player if touched
    {
        if (!objectToDamage.CompareTag("Player"))//Checks if object is not player
        {
            return;//Stops code
        }

        Health health = objectToDamage.GetComponent<Health>();//Gets Health script

        if (health != null)//Checks if Health exists
        {
            health.TakeDamage(damageAmount);//Damages player
        }
    }
}
