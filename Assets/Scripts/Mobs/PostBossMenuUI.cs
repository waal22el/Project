using UnityEngine;
using UnityEngine.SceneManagement;

public class PostBossMenuUI : MonoBehaviour
{
    public GameObject postBossMenuPanel;

    public void ShowMenu()
    {
        postBossMenuPanel.SetActive(true);
        Time.timeScale = 0; // Pausa spelet
    }

    public void ContinueGame()
    {
        Time.timeScale = 1; // Fortsätt spelet
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1); // Ladda nästa nivå
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}

