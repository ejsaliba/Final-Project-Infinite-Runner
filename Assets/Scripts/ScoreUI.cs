using UnityEngine;
using TMPro;

public class ScoreUI : MonoBehaviour
{
    [SerializeField] private TMP_Text currentScoreText;
    [SerializeField] private TMP_Text highScoreText;

    void Update()
    {
        if (ScoreManager.Instance == null) return;

        if (currentScoreText != null)
            currentScoreText.text = $"Score: {Mathf.FloorToInt(ScoreManager.Instance.CurrentScore)}";

        if (highScoreText != null)
            highScoreText.text = $"Best: {ScoreManager.Instance.HighScore}";
    }
}