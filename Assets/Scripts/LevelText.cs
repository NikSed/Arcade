using UnityEngine;
using TMPro;

public class LevelText : MonoBehaviour
{
    private TextMeshProUGUI _text;

    private void Awake()
    {
        _text = GetComponent<TextMeshProUGUI>();
    }

    private void Start()
    {
        ShowLevel();
    }

    private void ShowLevel()
    {
        _text.text = $"Level: {SceneLoadSystem.LevelNumber}";
    }
}