using UnityEngine;
using TMPro;

public class HealthText : MonoBehaviour
{
    private TextMeshProUGUI _text;

    private void Awake()
    {
        GlobalEventsManager.OnPlayerHit.AddListener(TextUpdate);

        _text = GetComponent<TextMeshProUGUI>();
    }

    private void Start()
    {
        TextUpdate(Player.CurrentHealth);
    }

    private void TextUpdate(float health)
    {
        _text.text = $"HP: {(int)health}";
    }
}