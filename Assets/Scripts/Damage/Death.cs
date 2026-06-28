using UnityEngine;

public abstract class Death : MonoBehaviour
{
    public abstract bool IsDead { get; protected set; }//Property child classes must override

    public abstract void Die();//Method child classes must override
}
