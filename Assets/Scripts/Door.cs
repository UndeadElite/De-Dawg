using System.Collections;
using UnityEngine;

public class Door : MonoBehaviour, IInteractable
{
    Animator doorAnimator;
    [SerializeField] AudioClip doorSfx;
    [SerializeField] AudioClip doorBellSfx;
    [SerializeField] PackageScript packageScript;
    public bool doorBell = false;
    bool hasRungDoorBell = false;

    void Start()
    {
        doorAnimator = GetComponent<Animator>();
        doorAnimator.SetBool("Opening", false);
    }

    public void DoorBellPlayer()
    {
        if (doorBell && !hasRungDoorBell)
        {
            hasRungDoorBell = true;
            StartCoroutine(GetTheFood());
        }
    }

    public void Interact()
    {
        if (hasRungDoorBell)
        {
            doorAnimator.SetBool("Opening", true);
            AudioSource.PlayClipAtPoint(doorSfx, transform.position, 0.5f);
            doorBell = false;
            StartCoroutine(GetPackage());
        }
    }

    IEnumerator GetTheFood()
    {
        AudioSource.PlayClipAtPoint(doorBellSfx, transform.position, 1f);
        yield return new WaitForSeconds(5f);
        hasRungDoorBell = false; // reset if you want to allow ringing again later
    }

    IEnumerator GetPackage()
    {
        yield return new WaitForSeconds(2f);
        Animator packageAnimator = packageScript.GetComponentInParent<Animator>();
        if (packageAnimator != null)
        {
            packageAnimator.SetBool("goInside", true);
        }
    }
}
