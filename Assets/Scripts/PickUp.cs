using UnityEngine;

public class PickUp : MonoBehaviour, IInteractable
{
    public bool DoIHaveFood = false;
    public void Interact()
    {
        gameObject.SetActive(false);
        DoIHaveFood = true;
    }
}
