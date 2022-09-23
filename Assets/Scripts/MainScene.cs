using UnityEngine;

public class MainScene : MonoBehaviour
{
    public void LoadFightScene()
    {
        SceneLoader.Load(SceneLoader.Scene.Fight);
    }

    public void LoadStatisticsScene()
    {
        SceneLoader.Load(SceneLoader.Scene.Statistics);
    }
}