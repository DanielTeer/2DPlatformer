using UnityEngine;

public class Goal : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)//Runs when we enters goal
    {
        if (!other.CompareTag("Player"))//Checks if object is not player
        {
            return;//Stops code
        }

        GameManager.instance.WinGame();//Calls victory screen
    }
}
