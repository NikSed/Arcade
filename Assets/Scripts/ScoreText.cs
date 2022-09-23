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

    private SaveData SetData()
    {
        var data = SaveManager.Load<SaveData>();

        List<int> list = new List<int>();

        if (data != null)
        {
            foreach (var item in data.Scores)
            {
                list.Add(data.Scores[item]);
            }
        }

        list.Add(_score);

        SaveData saveData = new SaveData();

        foreach (var item in list)
        {
            saveData.Scores.Add(list[item]);
        }

        return saveData;
    }
}
