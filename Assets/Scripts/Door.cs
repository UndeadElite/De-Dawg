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

    private void Update()
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
        while (doorBell)
        {
            Debug.Log("Door bell should play now");
            AudioSource.PlayClipAtPoint(doorBellSfx, transform.position, 1f);
            yield return new WaitForSeconds(3f);
        }
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
