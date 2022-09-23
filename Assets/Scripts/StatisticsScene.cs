using UnityEngine;
using System.Collections.Generic;
using TMPro;

public class StatisticsScene : MonoBehaviour
{
    [SerializeField] private Transform _scoreTableContentPrefab;
    [SerializeField] private Transform _contentContainer;

    private TextMeshProUGUI _scoreText;

    private List<int> _scoresList = new List<int>();

    private void Awake()
    {
        _scoreText = _scoreTableContentPrefab.GetChild(0).GetComponent<TextMeshProUGUI>();
    }

    private void Start()
    {
        var data = SaveManager.Load<SaveData>();

        _scoresList = data.Scores;

        Instantiate(_scoreTableContentPrefab, _contentContainer);
    }

}

public class ScoreItemView
{

}