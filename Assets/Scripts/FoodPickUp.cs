using UnityEngine;

public class PickUp : MonoBehaviour, IInteractable
{
    public GameObject ObjectOnPlayer;
    public static bool playerIsHolding = false;
    public static PickUp CurrentHeld = null;

    public void Interact()
    {
        if (!playerIsHolding)
        {
            // Not holding anything, pick up this item
            PickUpItem();
        }
    }



    private void PickUpItem()
    {
        playerIsHolding = true;
        CurrentHeld = this;
        ObjectOnPlayer.SetActive(true); // Show in hand
        gameObject.SetActive(false);    // Hide in world
    }
}