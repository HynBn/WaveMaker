using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void ChangeScene(int sceneID)
    {
        SceneManager.LoadScene(sceneID);
    }

    /// <summary>
    /// Quits the application or editor.
    /// </summary>
    public void Quit()
    {
    #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
    #endif
        Application.Quit();
    }

    public void GameOver()
    {
        SceneManager.LoadScene(GameData.GAME_OVER);
    }

    /// <summary>
    /// Toggles a given menu on or off.
    /// </summary>
    /// <param name="menu">The menu to toggle.</param>
    public void ToggleSubMenu(GameObject menu)
    {
        menu.SetActive(!menu.activeInHierarchy);
    }

    public void TogglePlay(bool running)
    {
        GameData.Reset();
        GameData.isRunning = running;
    }
}