using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public Animator checkpointAnimator;//Animator for checkpoint torch

    private bool isActivated;//Tracks if checkpoint is active

    public AudioSource checkpointAudioSource;//AudioSource on checkpoint

    private void OnTriggerEnter2D(Collider2D other)//Runs when something enters checkpoint
    {
        if (!other.CompareTag("Player"))//Checks if object is not player
        {
            return;//Stops code
        }

        GameManager.instance.SetCheckpoint(transform.position);//Saves checkpoint position

        if (isActivated)//Checks if checkpoint was already active
        {
            return;//Stops code
        }

        isActivated = true;//Marks checkpoint active

        if (checkpointAnimator != null)//Checks if Animator exists
        {
            checkpointAnimator.SetTrigger("TurnOn");//Plays checkpoint on animation
        }
        if (AudioManager.Instance != null)//Checks if AudioManager exists
        {
            AudioManager.Instance.PlayCheckpoint();//Plays checkpoint sound
        }

        if (checkpointAudioSource != null)//Checks if checkpoint audio exists
        {
            checkpointAudioSource.Play();//Plays checkpoint sound in world
        }
    }
}