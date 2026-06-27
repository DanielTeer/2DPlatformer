using UnityEngine;

public class MenuButtons : MonoBehaviour
{
    public void PlayButton()//Runs when Play button is pressed
    {
        GameManager.instance.StartGame();//Starts gameplay
    }

    public void MainMenuButton()//Runs when Main Menu button is pressed
    {
        Time.timeScale = 1f;//Unpauses game

        GameManager.instance.ShowMainMenu();//Shows main menu
    }

    public void CreditsButton()//Runs when Credits button is pressed
    {
        GameManager.instance.ShowCredits();//Shows credits screen
    }

    public void AudioButton()//Runs when Audio button is pressed
    {
        GameManager.instance.ShowAudioSettings();//Shows audio settings
    }

    public void RestartButton()//Runs when restart/play again is pressed
    {
        GameManager.instance.RestartLevel();//Restarts scene
    }

    public void QuitButton()//Runs when quit is pressed
    {
        GameManager.instance.QuitGame();//Quits game
    }
}
