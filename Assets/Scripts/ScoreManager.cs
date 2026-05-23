using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance { get; private set; }

    private const string HighScoreKey = "HighScore";

    public float CurrentScore { get; private set; }
    public int HighScore { get; private set; }
    public bool IsCounting { get; private set; }

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);

        HighScore = PlayerPrefs.GetInt(HighScoreKey, 0);
    }

    void Update()
    {
        if (!IsCounting) return;

        CurrentScore += Time.deltaTime;
        int rounded = Mathf.FloorToInt(CurrentScore);

        if (rounded > HighScore)
        {
            HighScore = rounded;
            PlayerPrefs.SetInt(HighScoreKey, HighScore);
            PlayerPrefs.Save();
        }
    }

    public void StartCounting() => IsCounting = true;

    public void StopCounting() => IsCounting = false;

    public void ResetScore()
    {
        CurrentScore = 0f;
        IsCounting = false;
    }

    public void ClearHighScore()
    {
        HighScore = 0;
        PlayerPrefs.DeleteKey(HighScoreKey);
        PlayerPrefs.Save();
    }
}