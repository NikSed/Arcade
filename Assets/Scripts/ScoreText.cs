using UnityEngine;
using TMPro;

public class ScoreText : MonoBehaviour
{
    public static int Score { get; private set; }

    [SerializeField] private int _scoreForNextLevel = 20;

    private const string ScoreKey = "Score";

    private static TextMeshProUGUI _text;

    private void Awake()
    {
        GlobalEventsManager.OnEnemyKill.AddListener(AddScore);
        GlobalEventsManager.OnLoadNextLevel.AddListener(SaveTempScore);

        _text = GetComponent<TextMeshProUGUI>();
    }

    private void Start()
    {
        LoadTempScore();
        ShowScore();
    }

    private void ShowScore()
    {
        _text.text = $"Score: {Score}";
    }

    private void AddScore()
    {
        Score++;
        ShowScore();

        if (Score >= _scoreForNextLevel)
        {
            GlobalEventsManager.OnLoadNextLevel.Invoke();
        }
    }

    private void SaveTempScore()
    {
        PlayerPrefs.SetInt(ScoreKey, Score);
    }

    private void LoadTempScore()
    {
        if (PlayerPrefs.HasKey(ScoreKey))
        {
            Score = PlayerPrefs.GetInt(ScoreKey);
            PlayerPrefs.DeleteKey(ScoreKey);
        }
        else
        {
            Score = 0;
        }
    }
}