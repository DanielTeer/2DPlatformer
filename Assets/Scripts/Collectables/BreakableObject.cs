using UnityEngine;

public class BreakableObject : MonoBehaviour
{
    private Death death;//Death behavior on this object

    void Start()//Runs once
    {
        death = GetComponent<Death>();//Gets any Death child script
    }

    private void OnTriggerEnter2D(Collider2D other)//Runs when something enters trigger
    {
        if (!other.GetComponent<ThrowWeapon>())//Checks if object is not thrown weapon
        {
            return;//Stops code
        }

        if (death != null)//Checks if death behavior exists
        {
            death.Die();//Calls overridden Die method
        }
    }
}
