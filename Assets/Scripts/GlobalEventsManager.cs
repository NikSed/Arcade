using UnityEngine;
using UnityEngine.Events;

public class GlobalEventsManager : MonoBehaviour
{
    public static UnityEvent OnEnemyKill = new UnityEvent();
    public static UnityEvent OnEnemyDestroy = new UnityEvent();

    public static UnityEvent OnPlayerKill = new UnityEvent();
    public static UnityEvent<float> OnPlayerHit = new UnityEvent<float>();
}