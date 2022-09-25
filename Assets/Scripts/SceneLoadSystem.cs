using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoadSystem : MonoBehaviour
{
    public enum Scene
    {
        Main,
        Fight,
        Statistics
    }

    private static SceneLoadSystem _instance;

    public static SceneLoadSystem Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new SceneLoadSystem();
            }

            return _instance;
        }
    }

    private const string MainSceneName = "MainScene";
    private const string FightSceneName = "FightScene";
    private const string StatisticsSceneName = "StatisticsScene";

    private void Awake()
    {
        if (_instance != null)
            Destroy(this);

        DontDestroyOnLoad(this);
    }

    public static void Load(Scene scene)
    {
        string loadingSceneName;

        switch (scene)
        {
            case Scene.Main:
                loadingSceneName = MainSceneName;
                break;
            case Scene.Fight:
                loadingSceneName = FightSceneName;
                break;
            case Scene.Statistics:
                loadingSceneName = StatisticsSceneName;
                break;
            default:
                loadingSceneName = MainSceneName;
                break;
        }

        SceneManager.LoadScene(loadingSceneName);
    }
}