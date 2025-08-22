using UnityEngine;

public class FoodSpawner : MonoBehaviour
{

    public GameObject[] foods; //0 = dogCan, 1 = steak, 2 = mystery, 3 = arm
    void Start()
    {
        foreach (var f in foods) f.SetActive(false);

        int index = NightManager.currentNight - 1;
        if(index >= 0 && index < foods.Length)
        {
            foods[index].SetActive(true);
        }
    }
}
