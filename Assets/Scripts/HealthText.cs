using UnityEngine;
using TMPro;

public class HealthText : MonoBehaviour
{
    private TextMeshProUGUI _text;

    private void Awake()
    {
        GlobalEventsManager.OnPlayerHit.AddListener(ShowHealth);

        _text = GetComponent<TextMeshProUGUI>();
    }

    private void Start()
    {
        ShowHealth(Player.CurrentHealth);
    }

    private void ShowHealth(float health)
    {
        _text.text = $"HP: {(int)Player.CurrentHealth}";
    }
}