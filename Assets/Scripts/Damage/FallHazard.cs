using UnityEngine;

public class FallHazard : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)//Runs when something enters fall hazard
    {
        if (!other.CompareTag("Player"))//Checks if object is not player
        {
            return;//Stops code
        }

        GameManager.instance.FallDeath();//Tells GameManager player fell
    }
}
