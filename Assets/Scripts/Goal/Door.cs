using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour
{
    public Animator doorAnimator;//Animator for the door

    public float victoryDelay = 1f;//Time to wait before victory screen

    private bool isOpen;//Tracks if door is open

    private bool victoryStarted;//Stops victory from being called more than once

    private void OnTriggerEnter2D(Collider2D other)//Runs when something enters door trigger
    {
        if (!other.CompareTag("Player"))//Checks if object is not player
        {
            return;//Stops code
        }

        if (GameManager.instance == null)//Checks if GameManager is missing
        {
            return;//Stops code
        }

        if (!GameManager.instance.HasKey())//Checks if player does not have key
        {
            Debug.Log("Door is locked. Find the key.");//Prints locked message

            return;//Stops code
        }

        if (victoryStarted)//Checks if victory already started
        {
            return;//Stops code
        }

        StartCoroutine(OpenDoorAndWin());//Opens door and waits before victory
    }

    IEnumerator OpenDoorAndWin()//Opens door then calls victory
    {
        victoryStarted = true;//Prevents this from running twice

        isOpen = true;//Marks door as open

        if (doorAnimator != null)//Checks if Animator exists
        {
            doorAnimator.SetTrigger("Open");//Plays open animation
        }

        Debug.Log("Door opened");//Prints test message

        yield return new WaitForSeconds(victoryDelay);//Waits before victory screen

        GameManager.instance.WinGame();//Calls victory screen
    }
}