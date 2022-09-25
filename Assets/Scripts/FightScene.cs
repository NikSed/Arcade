using UnityEngine;

public class FightScene : MonoBehaviour
{
    private void Awake()
    {
        GlobalEventsManager.OnPlayerKill.AddListener(LoadStatisticsScene);
    }

    private void OnDestroy()
    {
        SaveSystem.Save();
    }

    private void LoadStatisticsScene()
    {
        SceneLoadSystem.Load(SceneLoadSystem.Scene.Statistics);
    }
}