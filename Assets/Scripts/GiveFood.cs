using UnityEngine;

public class GiveFood : MonoBehaviour, IInteractable
{
    [SerializeField] PickUp pickUp;
    public bool HaveIGivenFood = false;

    //text pop up "Got + "___" !" and do the texting thing like a typewriter
    public void Interact()
    {
        if (pickUp.DoIHaveFood)
        {
            pickUp.DoIHaveFood = false;
            HaveIGivenFood = true;

            var inter = FindFirstObjectByType<InteractionManager>();
            if (inter != null)
            {
                inter.typeWriter.ShowText(""); // clears text
                inter.CheckForInteractable();  // updates text
            }

            //the gameobject.setactive to true (the food that is in the bowl and it turns on depending on which food type it is
        }
    }
}
