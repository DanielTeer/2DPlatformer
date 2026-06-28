using UnityEngine;

public class DeathDestroy : Death
{
    public float destroyDelay = 1f;//Time before object is destroyed

    public override bool IsDead { get; protected set; }//Tracks if object is dead

    public override void Die()//Destroys object when it dies
    {
        if (IsDead)//Checks if already dead
        {
            return;//Stops code
        }

        IsDead = true;//Marks object as dead

        Destroy(gameObject, destroyDelay);//Destroys this object after delay
    }
}
