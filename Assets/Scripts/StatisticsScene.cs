using UnityEngine;
using TMPro;

public class StatisticsScene : MonoBehaviour
{
    [SerializeField] private Transform _scoreTableContentPrefab;
    [SerializeField] private Transform _contentContainer;
    [SerializeField] private TextMeshProUGUI _currentScoreText;

    private void Awake()
    {
        _currentScoreText = _currentScoreText.GetComponent<TextMeshProUGUI>();
    }

    private void Start()
    {
        var data = SaveManager.Load<Data>();

        if (data != null)
        {
            data.Scores.Reverse();

            _currentScoreText.text = $"Last score: {data.Scores[0]}";

            data.Scores.RemoveAt(0);

            foreach (var score in data.Scores)
            {
                ItemInstatiate(score);
            }
        }
    }

    private void ItemInstatiate(int score)
    {
        Transform scoreItem = Instantiate(_scoreTableContentPrefab, _contentContainer);
        TextMeshProUGUI scoreText = scoreItem.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        scoreText.text = score.ToString();
    }

    public void LoadMainScene()
    {
        SceneLoader.Load(SceneLoader.Scene.Main);
    }
}