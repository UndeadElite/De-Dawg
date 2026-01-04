using UnityEngine;

public class GiveFood : MonoBehaviour, IInteractable
{
    [SerializeField] private PickUp pickUp;
    public CutsceneStart cutsceneStart;
    public bool HaveIGivenFood = false;

    public void Interact()
    {
        PickUp targetPickUp = pickUp;

        if ((pickUp != null && pickUp.DoIHaveFood) ||
            (cutsceneStart != null && cutsceneStart.pickUp != null && cutsceneStart.pickUp.DoIHaveFood))
        {
            // If the Timeline PickUp is true, assign it to targetPickUp so the InteractionManager sees it
            if (targetPickUp != null && !targetPickUp.DoIHaveFood && cutsceneStart.pickUp.DoIHaveFood)
                targetPickUp = cutsceneStart.pickUp;

            targetPickUp.DoIHaveFood = false;
            HaveIGivenFood = true;

            var inter = FindFirstObjectByType<InteractionManager>();
            if (inter != null)
            {
                inter.typeWriter.ShowText("");
                inter.CheckForInteractable();
            }
        }
    }
}
