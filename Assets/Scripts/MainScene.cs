using UnityEngine;

public class MainScene : MonoBehaviour
{
    public void LoadFightScene()
    {
        SceneLoadSystem.Load(SceneLoadSystem.Scene.NextLevel);
    }

    public void LoadStatisticsScene()
    {
        SceneLoadSystem.Load(SceneLoadSystem.Scene.Statistics);
    }
}