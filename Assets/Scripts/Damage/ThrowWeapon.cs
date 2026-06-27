using UnityEngine;

public class ThrowWeapon : MonoBehaviour
{
    public int damageAmount = 1;//Damage the weapon gives enemies

    public float lifeTime = 3f;//How long the weapon stays alive

    public float spinSpeed = 720f;//How fast the weapon spins

    private bool hasHit;//Tracks if weapon already hit something

    private Collider2D weaponCollider;//The weapons Collider2D

    void Start()//Runs once
    {
        weaponCollider = GetComponent<Collider2D>();//Gets the weapons collider

        Destroy(gameObject, lifeTime);//Destroys weapon after time
    }

    void Update()//Runs every frame
    {
        transform.Rotate(0, 0, spinSpeed * Time.deltaTime);//Spins the weapon
    }

    private void OnTriggerEnter2D(Collider2D other)//Runs when weapon enters a trigger
    {
        DamageEnemy(other.gameObject);//Tries to damage enemy
    }

    private void OnCollisionEnter2D(Collision2D collision)//Runs when weapon collides
    {
        DamageEnemy(collision.gameObject);//Tries to damage enemy
    }

    void DamageEnemy(GameObject objectHit)//Checks if object hit is an enemy
    {
        if (hasHit)//Checks if weapon already hit something
        {
            return;//Stops double damage
        }

        EnemyHealth enemyHealth = objectHit.GetComponent<EnemyHealth>();//Gets EnemyHealth from object hit

        if (enemyHealth == null)//Checks if EnemyHealth was not found
        {
            return;//Stops code
        }

        hasHit = true;//Marks weapon as already used

        if (weaponCollider != null)//Checks if weapon collider exists
        {
            weaponCollider.enabled = false;//Turns off weapon collider so it cannot hit again
        }

        enemyHealth.TakeDamage(damageAmount);//Damages the enemy

        Destroy(gameObject);//Destroys weapon after hitting enemy
    }
}