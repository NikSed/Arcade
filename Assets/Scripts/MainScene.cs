using UnityEngine;

public class MainScene : MonoBehaviour
{
    public void LoadFightScene()
    {
        SceneLoadSystem.Load(SceneLoadSystem.Scene.Fight);
    }

    public void LoadStatisticsScene()
    {
        SceneLoadSystem.Load(SceneLoadSystem.Scene.Statistics);
    }
}