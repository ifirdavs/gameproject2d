using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [Header("Game Over")]
    [SerializeField] private GameObject gameOverScreen;
    [SerializeField] private AudioClip gameOverSound;

    [Header("Pause")]
    [SerializeField] private GameObject pauseScreen;

    [Header("Finish")]
    [SerializeField] private GameObject completeScreen;

    private void Awake()
    {
        gameOverScreen.SetActive(false);
        pauseScreen.SetActive(false);
        completeScreen.SetActive(false);

        // Ensure time scale is normal at the start
        Time.timeScale = 1;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // If pause screen already active unpause and vice versa
            PauseGame(!pauseScreen.activeInHierarchy);
        }
    }

    #region Game Over
    // Activate game over screen and freeze the game
    public void GameOver()
    {
        gameOverScreen.SetActive(true);
        SoundManager.instance.PlaySound(gameOverSound);

        // Freeze the game
        Time.timeScale = 0;
    }

    // Restart level
    public void Restart()
    {
        Time.timeScale = 1; // Reset time scale to normal before reloading
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    // Restart game
    public void RestartGame()
    {
        Time.timeScale = 1; // Reset time scale to normal before reloading
        SceneManager.LoadScene(1);
    }

    // Main menu
    public void MainMenu()
    {
        Time.timeScale = 1; // Reset time scale to normal before reloading
        SceneManager.LoadScene(0);
    }

    // Quit game/exit play mode if in Editor
    public void Quit()
    {
        Application.Quit(); // Quits the game (only works in build)

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false; // Exits play mode (will only be executed in the editor)
#endif
    }
    #endregion

    #region Pause
    public void PauseGame(bool status)
    {
        // If status == true pause | if status == false unpause
        pauseScreen.SetActive(status);

        // When pause status is true change timescale to 0 (time stops)
        // When it's false change it back to 1 (time goes by normally)
        Time.timeScale = status ? 0 : 1;
    }

    public void SoundVolume()
    {
        SoundManager.instance.ChangeSoundVolume(0.2f);
    }

    public void MusicVolume()
    {
        SoundManager.instance.ChangeMusicVolume(0.2f);
    }
    #endregion

    #region Game Complete
    // Activate Game Complete screen and freeze the game
    public void GameComplete()
    {
        completeScreen.SetActive(true);

        // Freeze the game
        Time.timeScale = 0;
    }
    #endregion

    #region Start
    // Start the game
    public void StartGame()
    {
        Time.timeScale = 1; // Ensure time scale is normal when starting
        SceneManager.LoadScene(1);
    }
    #endregion
}
