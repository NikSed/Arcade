using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoadSystem : MonoBehaviour
{
    public enum Scene
    {
        Main,
        NextLevel,
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

    public static int LevelNumber { get; private set; } = 0;

    [SerializeField] private static int _maxLevel = 2;

    private const string MainSceneName = "MainScene";
    private const string StatisticsSceneName = "StatisticsScene";

    private void Awake()
    {
        PlayerPrefs.DeleteAll();

        if (_instance != null)
            Destroy(this);

        DontDestroyOnLoad(this);

        GlobalEventsManager.OnLoadNextLevel.AddListener(LoadNextLevel);
    }

    public static void Load(Scene scene)
    {
        string loadingSceneName;

        switch (scene)
        {
            case Scene.Main:
                loadingSceneName = MainSceneName;
                LevelNumber = default;
                break;
            case Scene.NextLevel:
                LoadNextLevel();
                return;
            case Scene.Statistics:
                loadingSceneName = StatisticsSceneName;
                break;
            default:
                loadingSceneName = MainSceneName;
                break;
        }

        SceneManager.LoadScene(loadingSceneName);
    }

    public static void LoadNextLevel()
    {
        if (LevelNumber < _maxLevel)
        {
            LevelNumber++;

            SceneManager.LoadScene(LevelNumber.ToString());
        }
    }
}