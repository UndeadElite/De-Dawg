using UnityEngine;

public class GiveFood : MonoBehaviour, IInteractable
{
    PickUp pickUp;
    public bool HaveIGivenFood = false;

    //text pop up "Got + "___" !" and do the texting thing like a typewriter
    public void Interact()
    {
        if (pickUp.DoIHaveFood)
        {
            pickUp.DoIHaveFood = false;
            HaveIGivenFood = true;
        }
        else
        {
            //do the typewriter text saying you dont have the food yet
        }
    }
}
