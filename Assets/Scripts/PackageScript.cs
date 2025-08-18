using UnityEngine;

public class PackageScript : MonoBehaviour, IInteractable
{

    public GameObject confettiCannon;
    public GameObject openedBox;
    public GameObject smokeVFX;

    public GameObject Food;
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
