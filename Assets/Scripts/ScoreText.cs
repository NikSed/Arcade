using UnityEngine;
using TMPro;

public class ScoreText : MonoBehaviour
{
    public static int Score { get; private set; }

    private TextMeshProUGUI _text;

    private void Awake()
    {
        GlobalEventsManager.OnEnemyKill.AddListener(AddScore);

        Score = 0;
    }

    private void Start()
    {
        _text = GetComponent<TextMeshProUGUI>();
    }

    private void AddScore()
    {
        Score++;
        _text.text = $"Score: {Score}";
    }
}
