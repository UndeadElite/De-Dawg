using UnityEngine;

public class InteractionManager : MonoBehaviour
{
    public float interactionDistance = 3f;
    public LayerMask interactableLayer = 6;
    public Transform playerCamera;

    private IInteractable currentInteractable;
    private Outline currentOutline;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Update()
    {
        CheckForInteractable();

        if (currentInteractable != null && Input.GetKeyDown(KeyCode.E))
        {
            currentInteractable.Interact();
        }
    }

    void CheckForInteractable()
    {
        Ray ray = new Ray(playerCamera.position, playerCamera.forward);
        if (Physics.Raycast(ray, out RaycastHit hit, interactionDistance, interactableLayer))
        {
            IInteractable interactable = hit.collider.GetComponent<IInteractable>();

            if (interactable != null)
            {
                if (currentInteractable != interactable)
                {
                    ResetOutline();
                    currentInteractable = interactable;
                    currentOutline = hit.collider.GetComponent<Outline>();

                    if (currentOutline != null)
                    {
                        currentOutline.enabled = true;
                    }
                }
                return;
            }
        }
        ResetOutline();
    }

    void ResetOutline()
    {
        if (currentOutline != null)
        {
            currentOutline.enabled = false;
        }
        currentInteractable = null;
        currentOutline = null;
    }
}