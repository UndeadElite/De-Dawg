using UnityEngine;
using UnityEngine.SceneManagement;

public class Bed : MonoBehaviour, IInteractable
{
    [SerializeField] GiveFood giveFood;
    public void Interact()
    {
        if (giveFood.HaveIGivenFood)
        {
            //play cutscene

            NightManager.currentNight++;
            SceneManager.LoadScene("Night" + NightManager.currentNight);

        }
    }
}
