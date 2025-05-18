using UnityEngine;
using UnityEngine.SceneManagement;

public class ContinueButton : MonoBehaviour
{
    public void LoadNextGame()
    {
        SceneManager.LoadScene("Dungeons");
    }
}

