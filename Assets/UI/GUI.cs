using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GUI : MonoBehaviour
{
    [SerializeField] private TMP_Text enemyCoin, coinCounter;
    [SerializeField] private Slider enemyHealth, healthBar;
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private Toggle speedUp;


    private void Update()
    {
        enemyCoin.text = GameData.enemyGold.ToString();
        coinCounter.text = GameData.gold.ToString();
        enemyHealth.value = GameData.enemyLives;
        healthBar.value = GameData.life;
        if (GameData.life <= 0)
        {
            PauseGame();
        }
    }

    /// <summary>
    /// Pausemenu script parts by <see href="https://github.com/boTimPact"/>
    /// </summary>
    public void PauseGame()
    {
        GameData.isPaused = true;
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
    }

    public void ResumeGame()
    {
        GameData.isPaused = false;
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
    }

    public void RestartScene()
    {
        ResumeGame();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void GoToMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(GameData.MAIN_MENU);
    }

    public void QuitGame()
    {
        SceneManager.LoadScene(GameData.GAME_OVER);
    }

    public void ToggleSpeed()
    {
        if (speedUp.isOn)
        {
            Time.timeScale = 2;
        } else
        {
            Time.timeScale = 1;
        }
    }

    public void TogglePlay(bool running)
    {
        GameData.Reset();
        GameData.isRunning = running;
    }
}
