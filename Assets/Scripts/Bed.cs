using UnityEngine;

public class Bed : MonoBehaviour, IInteractable
{
    public int nightToSet = 1;
    GiveFood giveFood;
    public void Interact()
    {
        if (giveFood.HaveIGivenFood)
        {
            //play cutscene

            NightManager.currentNight = nightToSet;
            Debug.Log("Night set to " + nightToSet);
        }
    }
}
