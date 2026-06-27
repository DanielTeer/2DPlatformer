using UnityEngine;

public class Collectible : MonoBehaviour
{
    public int scoreValue = 1;//Points this collectible gives

    private bool isCollected;//Tracks if item was collected

    private void OnTriggerEnter2D(Collider2D other)//Runs when something enters collectible
    {
        if (!other.CompareTag("Player"))//Checks if object is not player
        {
            return;//Stops code
        }

        if (isCollected)//Checks if already collected
        {
            return;//Stops code
        }

        isCollected = true;//Marks item collected

        GameManager.instance.AddScore(scoreValue);//Adds score

        if (AudioManager.Instance != null)//Checks if AudioManager exists
        {
            AudioManager.Instance.PlayCollect();//Plays collect sound
        }

        gameObject.SetActive(false);//Hides item so it stays gone after respawn
    }
}
