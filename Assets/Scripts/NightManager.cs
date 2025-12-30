using UnityEngine;

public class NightManager : MonoBehaviour
{
    [SerializeField] int currentNight = 1;
    public static int CurrentNight;

    void Awake()
    {
        if (CurrentNight == 0)
            CurrentNight = currentNight;
    }
}