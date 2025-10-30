using UnityEngine;

public class PackageScript : MonoBehaviour, IInteractable
{

    public GameObject confettiCannon;
    public GameObject openedBox;
    public GameObject smokeVFX;

    public GameObject Food;
    Animator boxAnimator;

    Door doorScript;
    private void Start()
    {
        boxAnimator = GetComponentInParent<Animator>();
    }

    public void Interact()
    {
        Debug.Log("interacted with foodbox");

        gameObject.SetActive(false);

        confettiCannon.SetActive(true);
        smokeVFX.SetActive(true);
        openedBox.SetActive(true);
        Food.SetActive(true);
    }
}
