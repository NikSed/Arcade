using UnityEngine;
using System.Collections.Generic;
using TMPro;

public class ScoreText : MonoBehaviour
{
    private int _score = 0;
    private TextMeshProUGUI _text;

    private void Awake()
    {
        GlobalEventsManager.OnEnemyKill.AddListener(AddScore);
        GlobalEventsManager.OnPlayerKill.AddListener(Save);
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

    private void Save()
    {
        SaveManager.Save(SetData());
    }

    private Data SetData()
    {
        Data data = SaveManager.Load<Data>();

        List<int> list = new List<int>();

        if (data != null)
        {
            foreach (var score in data.Scores)
            {
                list.Add(score);
            }
        }

        list.Add(_score);

        Data saveData = new Data();

        foreach (var item in list)
        {
            saveData.Scores.Add(item);
        }

        return saveData;
    }
}
