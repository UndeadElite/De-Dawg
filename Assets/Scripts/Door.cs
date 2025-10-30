using System.Collections;
using UnityEngine;

public class Door : MonoBehaviour, IInteractable
{
    Animator doorAnimator;
    [SerializeField] AudioClip doorSfx;
    [SerializeField] AudioClip doorBellSfx;
    [SerializeField] PackageScript packageScript;
    public bool doorBell = false;
    bool stoppedDoorBell = false;

    void Start()
    {
        doorAnimator = GetComponent<Animator>();
        doorAnimator.SetBool("Opening", false);
    }

    void Update()
    {
        if (doorBell)
        {
            //this shit cannot be in update - it'll keep creating new one shots
            StartCoroutine(GetTheFood());
            stoppedDoorBell = true;
        }
    }
    public void Interact()
    {
        if (stoppedDoorBell)
        {
            doorAnimator.SetBool("Opening", true);
            AudioSource.PlayClipAtPoint(doorSfx, gameObject.transform.position, 0.5f);
            doorBell = false;

            StartCoroutine(GetPackage());
        }
    }

    IEnumerator GetTheFood()
    {
        AudioSource.PlayClipAtPoint(doorBellSfx, gameObject.transform.position, 1f);
        yield return new WaitForSeconds(5f);
    }

    IEnumerator GetPackage()
    {
        yield return new WaitForSeconds(2f);
        Debug.Log("Coroutine reached");

        Animator packageAnimator = packageScript.GetComponentInParent<Animator>();
        if(packageAnimator != null)
        {
            packageAnimator.SetBool("goInside", true);
        }
    }
}
