using UnityEngine;
using UnityEngine.SceneManagement;

public class Bed : MonoBehaviour, IInteractable
{
    [SerializeField] GiveFood giveFood;
    [SerializeField] private GameObject bedCutscene;
    [SerializeField] GameObject screenText;
    [SerializeField] CutsceneStart cutsceneStart;
    public void Interact()
    {
        if (giveFood.HaveIGivenFood)
        {
            //play cutscene
            screenText.SetActive(false);
            bedCutscene.SetActive(true);
            cutsceneStart.Activate();
        }
    }
}
