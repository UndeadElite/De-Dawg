using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InteractionManager : MonoBehaviour
{

    [SerializeField] Animator armAnimator;
    public float interactionDistance = 3f;
    public LayerMask interactableLayer = 6;
    public Transform playerCamera;

    private IInteractable currentInteractable;
    private Outline currentOutline;

    public TMP_Text interactText;
    public TypewriterText typeWriter;
    Dictionary<string, string> tagTexts;
    Dictionary<string, Func<string>> specialTexts;

    GiveFood giveFood;
    PickUp pickUp;

    private void Start()
    {
        giveFood = FindFirstObjectByType<GiveFood>();
        pickUp = FindFirstObjectByType<PickUp>();
        tagTexts = new Dictionary<string, string>
        {
            {"Bed", "Go to Sleep? (E)" },
            {"Dog", "Give food? (E)" },
            {"Box", "Open Box? (E)" }
        };
        specialTexts = new Dictionary<string, Func<string>>
        {
            {"Bed", () => !giveFood.HaveIGivenFood ? "Get the Food First" : tagTexts["Bed"]},
            {"Dog", () => !pickUp.DoIHaveFood ? "I need the Food First" : tagTexts["Dog"]}
        };
    }
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
                    armAnimator.SetBool("Interact", true);

                    string tag = hit.collider.tag;

                    if (specialTexts.ContainsKey(tag))
                    {
                        typeWriter.ShowText(specialTexts[tag]());
                    }
                    else if (tagTexts.ContainsKey(tag))
                    {
                        typeWriter.ShowText(tagTexts[tag]);
                    }
                    else
                    {
                        typeWriter.ShowText("Interact with E");
                    }
                }
                return;
            }
        }
        ResetOutline();
        armAnimator.SetBool("Interact", false);
        interactText.SetText("");
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