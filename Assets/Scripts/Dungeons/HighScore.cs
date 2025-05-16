using UnityEngine;
using TMPro;


public class HighScore : MonoBehaviour
{
    public int currentDungeonCount = 0;
    public int highScore = 0;

    public TMP_Text currentScoreText;
    public TMP_Text highScoreText;

    void Start()
    {
        highScore = PlayerPrefs.GetInt("HighScore", 0);
        UpdateUI();
    }

    public void EnterNewDungeon()
    {
        currentDungeonCount++;
        if (currentDungeonCount > highScore)
        {
            highScore = currentDungeonCount;
            PlayerPrefs.SetInt("HighScore", highScore);
        }
        UpdateUI();
    }

    void UpdateUI()
    {
        if (currentScoreText != null)
            currentScoreText.text = "Dungeons: " + currentDungeonCount;

        if (highScoreText != null)
            highScoreText.text = "High Score: " + highScore;
    }

    public void ResetScore()
    {
        currentDungeonCount = 0;
        UpdateUI();
    }
}