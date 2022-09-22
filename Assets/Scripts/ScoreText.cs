using UnityEngine;
using TMPro;

public class ScoreText : MonoBehaviour
{
    private int _score = 0;
    private TextMeshProUGUI _text;

    private void Awake()
    {
        GlobalEventsManager.OnEnemyKill.AddListener(AddScore);
    }

    private void Start()
    {
        _text = GetComponent<TextMeshProUGUI>();
    }

    private void AddScore()
    {
        _score++;
        _text.text = $"Score: {_score}";
    }
}
