using UnityEngine;

public class KeyCollectible : MonoBehaviour
{
    private bool isCollected;//Tracks if key was already collected

    private void OnTriggerEnter2D(Collider2D other)//Runs when something enters key trigger
    {
        if (!other.CompareTag("Player"))//Checks if object is not player
        {
            return;//Stops code
        }

        if (isCollected)//Checks if key was already collected
        {
            return;//Stops code
        }

        isCollected = true;//Marks key as collected

        if (GameManager.instance != null)//Checks if GameManager exists
        {
            GameManager.instance.GetKey();//Tells GameManager player has key
        }

        if (AudioManager.Instance != null)//Checks if AudioManager exists
        {
            AudioManager.Instance.PlayCollect();//Plays collect sound
        }

        gameObject.SetActive(false);//Hides key after collection
    }
}
