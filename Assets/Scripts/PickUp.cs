using UnityEngine;

public class PickUp : MonoBehaviour, IInteractable
{
    public bool DoIHaveFood = false;

    MeshCollider meshCollider;
    MeshRenderer meshRenderer;
    void Start()
    {
        meshCollider = gameObject.GetComponent<MeshCollider>();
        meshRenderer = gameObject.GetComponent<MeshRenderer>();
    }
    public void Interact()
    {
        meshCollider.enabled = false;
        meshRenderer.enabled = false;
        DoIHaveFood = true;
    }
}
