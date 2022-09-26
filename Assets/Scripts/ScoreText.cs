using UnityEngine;
using TMPro;

public class ScoreText : MonoBehaviour
{
    public static int Score { get; private set; }

    private TextMeshProUGUI _text;

    private void Awake()
    {
        GlobalEventsManager.OnEnemyKill.AddListener(AddScore);

        _text = GetComponent<TextMeshProUGUI>();
    }

    private void Start()
    {
        Score = 0;
    }

    private void AddScore()
    {
        Score++;

        if (Score >= 0)
        {
            _text.text = $"Score: {Score}";
        }
    }
}
