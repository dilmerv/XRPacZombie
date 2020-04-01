using DilmerGames.Core;
using TMPro;
using UnityEngine;

public class UIManager : Singleton<UIManager>
{
    [SerializeField]
    private TextMeshProUGUI scoreText;

    public void IncrementScore()
    {
        ScoreManager.Instance.score++;
        scoreText.text = $"SCORE: {ScoreManager.Instance.score}";
    }
}
