using UnityEngine;

public class PackageScript : MonoBehaviour, IInteractable
{
    public MeshRenderer boxRenderer;
    public MeshCollider meshCollider;
    public BoxCollider boxCollider;

    public GameObject confettiCannon;
    public GameObject openedBox;
    public void Interact()
    {
        Debug.Log("interacted with foodbox");
        boxRenderer.enabled = false;
        meshCollider.enabled = false;
        boxCollider.enabled = false;

        confettiCannon.SetActive(true);
        openedBox.SetActive(true);
    }
}
