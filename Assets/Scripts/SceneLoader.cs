using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public enum Scene
    {
        Main,
        Fight,
        Statistics
    }

    private static SceneLoader _instance;

    public static SceneLoader Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new SceneLoader();
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