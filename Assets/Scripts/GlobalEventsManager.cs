using UnityEngine;
using UnityEngine.Events;

public class GlobalEventsManager : MonoBehaviour
{
    public static UnityEvent OnEnemyDestroy = new UnityEvent();
}