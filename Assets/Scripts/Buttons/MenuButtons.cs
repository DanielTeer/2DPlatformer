using UnityEngine;

public class MenuButtons : MonoBehaviour
{
    public void PlayButton()//Runs when Play button is pressed
    {
        GameManager.instance.PlayButtonPressed();//Starts game or resets after game ended
    }

    public void PlayAgainButton()//Runs when Play Again button is pressed
    {
        GameManager.instance.PlayAgain();//Resets gameplay and starts right away
    }

    public void MainMenuButton()//Runs when Main Menu button is pressed
    {
        GameManager.instance.ShowMainMenu();//Shows main menu without resetting
    }

    public void CreditsButton()//Runs when Credits button is pressed
    {
        GameManager.instance.ShowCredits();//Shows credits screen
    }

    public void AudioButton()//Runs when Audio button is pressed
    {
        GameManager.instance.ShowAudioSettings();//Shows audio settings screen
    }

    public void RestartButton()//Runs when restart/play again is pressed
    {
        GameManager.instance.PlayAgain();//Resets gameplay and starts right away
    }

    public void QuitButton()//Runs when quit is pressed
    {
        GameManager.instance.QuitGame();//Quits game
    }
}