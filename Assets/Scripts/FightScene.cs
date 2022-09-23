using UnityEngine;

public class FightScene : MonoBehaviour
{
    private void Awake()
    {
        GlobalEventsManager.OnPlayerKill.AddListener(LoadStatisticsScene);
    }

    private void LoadStatisticsScene()
    {
        SceneLoader.Load(SceneLoader.Scene.Statistics);
    }
}