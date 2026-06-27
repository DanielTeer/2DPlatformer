using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;//Lets other scripts find GameManager

    public Transform player;//Player object

    public int startingLives = 3;//Lives player starts with

    public int currentLives;//Current lives

    public int score;//Current score

    public TMP_Text scoreText;//UI score text

    public TMP_Text livesText;//UI lives text

    public TMP_Text healthText;//UI health text

    public GameObject titleScreen;//Title screen panel

    public GameObject mainMenuScreen;//Main menu panel

    public GameObject gameplayScreen;//Gameplay UI panel

    public GameObject creditsScreen;//Credits panel

    public GameObject audioScreen;//Audio settings panel

    public GameObject gameOverScreen;//Game over panel

    public GameObject victoryScreen;//Victory panel

    private Vector3 checkpointPosition;//Last checkpoint position

    private Health playerHealth;//Players Health script

    private PlayerPawn playerPawn;//Players pawn script

    private bool gameStarted;//Tracks if game has started

    public HealthUI healthUI;//Heart health UI script

    public KeyUI keyUI;//Key UI script

    public bool hasKey;//Tracks if player collected the key

    void Awake()//Runs before Start
    {
        if (instance == null)//Checks if no GameManager exists
        {
            instance = this;//Sets this as GameManager
        }
        else
        {
            Destroy(gameObject);//Destroys duplicate GameManager
        }
    }

    void Start()//Runs once
    {
        Time.timeScale = 1f;//Makes sure game is not paused

        currentLives = startingLives;//Sets current lives

        checkpointPosition = player.position;//Sets starting checkpoint

        playerHealth = player.GetComponent<Health>();//Gets player Health

        playerPawn = player.GetComponent<PlayerPawn>();//Gets player pawn

        ShowTitleScreen();//Starts on title screen

        UpdateScoreUI();//Updates score UI

        UpdateLivesUI();//Updates lives UI

        if (keyUI != null)//Checks if KeyUI exists
        {
            keyUI.ShowNoKey();//Shows player starts without key
        }
    }

    void Update()//Runs every frame
    {
        if (!gameStarted && titleScreen.activeSelf && Input.anyKeyDown)//Checks for any key on title screen
        {
            ShowMainMenu();//Goes to main menu
        }
    }

    public void StartGame()//Starts gameplay
    {
        gameStarted = true;//Marks game as started

        Time.timeScale = 1f;//Unpauses game

        HideAllScreens();//Turns off menu screens

        gameplayScreen.SetActive(true);//Turns on gameplay UI
    }

    public void SetCheckpoint(Vector3 newCheckpointPosition)//Saves checkpoint
    {
        checkpointPosition = newCheckpointPosition;//Stores checkpoint position

        Debug.Log("Checkpoint saved");//Prints test message
    }

    public void PlayerLostLife()//Runs when player health reaches zero
    {
        currentLives--;//Removes a life

        UpdateLivesUI();//Updates lives UI

        if (currentLives > 0)//Checks if lives remain
        {
            RespawnPlayer();//Respawns player
        }
        else
        {
            GameOver();//Runs game over
        }
    }

    public void FallDeath()//Runs when player falls too far
    {
        PlayerLostLife();//Uses same life loss code
    }

    void RespawnPlayer()//Respawns player at checkpoint
    {
        playerPawn.StopMovement();//Stops player movement

        player.position = checkpointPosition;//Moves player to checkpoint

        playerHealth.HealFull();//Restores player health

        Debug.Log("Player respawned");//Prints test message
    }

    public void AddScore(int amount)//Adds points
    {
        score += amount;//Adds to score

        UpdateScoreUI();//Updates score UI
    }
    public void GetKey()//Runs when player collects the key
    {
        hasKey = true;//Stores that player has the key

        if (keyUI != null)//Checks if KeyUI exists
        {
            keyUI.ShowHasKey();//Updates key UI
        }

        Debug.Log("Player collected the key");//Prints test message
    }

    public bool HasKey()//Lets other scripts check if player has key
    {
        return hasKey;//Returns true or false
    }

    public void UpdateHealthUI(int currentHealth, int maxHealth)//Updates health display
    {
        if (healthText != null)//Checks if health text exists
        {
            healthText.text = "Health: " + currentHealth + " / " + maxHealth;//Sets health text
        }

        if (healthUI != null)//Checks if heart UI exists
        {
            healthUI.UpdateHearts(currentHealth);//Updates heart images
        }
    }

    void UpdateScoreUI()//Updates score display
    {
        if (scoreText != null)//Checks if score text exists
        {
            scoreText.text = "Score: " + score;//Sets score text
        }
    }

    void UpdateLivesUI()//Updates lives display
    {
        if (livesText != null)//Checks if lives text exists
        {
            livesText.text = "Lives: " + currentLives;//Sets lives text
        }
    }

    public void WinGame()//Runs when player reaches door
    {
        if (AudioManager.Instance != null)//Checks if AudioManager exists
        {
            AudioManager.Instance.PlayVictory();//Plays victory sound
        }

        Time.timeScale = 0f;//Pauses game

        HideAllScreens();//Turns off screens

        victoryScreen.SetActive(true);//Shows victory screen

    }

    void GameOver()//Runs when player has no lives
    {
        if (AudioManager.Instance != null)//Checks if AudioManager exists
        {
            AudioManager.Instance.PlayGameOver();//Plays game over sound
        }

        Time.timeScale = 0f;//Pauses game

        HideAllScreens();//Turns off screens

        gameOverScreen.SetActive(true);//Shows game over screen
    }

    public void ShowTitleScreen()//Shows title screen
    {
        HideAllScreens();//Turns off screens

        titleScreen.SetActive(true);//Turns title on
    }

    public void ShowMainMenu()//Shows main menu
    {
        HideAllScreens();//Turns off screens

        mainMenuScreen.SetActive(true);//Turns main menu on
    }

    public void ShowCredits()//Shows credits screen
    {
        HideAllScreens();//Turns off screens

        creditsScreen.SetActive(true);//Turns credits on
    }

    public void ShowAudioSettings()//Shows audio settings screen
    {
        HideAllScreens();//Turns off screens

        audioScreen.SetActive(true);//Turns audio screen on
    }

    public void RestartLevel()//Restarts current scene
    {
        Time.timeScale = 1f;//Unpauses game

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);//Reloads scene
    }

    public void QuitGame()//Quits game
    {
        Application.Quit();//Quits built game

        Debug.Log("Quit Game");//Shows quit message in editor
    }

    void HideAllScreens()//Turns off all UI screens
    {
        titleScreen.SetActive(false);//Turns title screen off

        mainMenuScreen.SetActive(false);//Turns main menu off

        gameplayScreen.SetActive(false);//Turns gameplay UI off

        creditsScreen.SetActive(false);//Turns credits off

        audioScreen.SetActive(false);//Turns audio screen off

        gameOverScreen.SetActive(false);//Turns game over off

        victoryScreen.SetActive(false);//Turns victory off
    }
}