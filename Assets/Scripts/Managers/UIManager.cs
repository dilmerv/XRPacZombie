using DilmerGames.Core;
using TMPro;
using UnityEngine;

public class UIManager : Singleton<UIManager>
{
    [SerializeField]
    private TextMeshProUGUI scoreText;

    [SerializeField]
    private TextMeshProUGUI timerText;

    public void IncrementScore()
    {
        ScoreManager.Instance.score++;
        scoreText.text = $"SCORE: {ScoreManager.Instance.score}";
    }

    public void UpdateTimer(string timeValue)
    {
        timerText.text = $"{timeValue}";
    }
}
