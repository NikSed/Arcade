using UnityEngine;

public class LevelScene : MonoBehaviour
{
    private void Awake()
    {
        GlobalEventsManager.OnPlayerKill.AddListener(LoadStatisticsScene);
    }

    private void LoadStatisticsScene()
    {
        SaveSystem.Save();
        SceneLoadSystem.Load(SceneLoadSystem.Scene.Statistics);
    }
}