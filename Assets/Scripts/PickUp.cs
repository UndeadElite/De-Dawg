using UnityEngine;

public class PickUp : MonoBehaviour, IInteractable
{
    public bool DoIHaveFood = false;
    [SerializeField] Animator anim;
    public void Interact()
    {
        gameObject.SetActive(false);
        DoIHaveFood = true;


        anim.SetTrigger("Grab");
        anim.SetBool("Interact", false);
    }
}
