using System.Collections;
using UnityEngine;

public class Door : MonoBehaviour, IInteractable
{
    Animator doorAnimator;
    [SerializeField] AudioClip doorSfx;
    [SerializeField] AudioClip doorBellSfx;
    bool doorBell = false;

    void Start()
    {
        doorAnimator = GetComponent<Animator>();
        doorAnimator.SetBool("Opening", false);
    }

    void Update()
    {
        if (doorBell)
        {
            StartCoroutine("getTheFood");
        }
    }
    public void Interact()
    {
        doorAnimator.SetBool("Opening", true);
        doorOpeningSfx();

        //WaitForSeconds(2f);
        //play a animation where the package hovers first outside the door then floats inside the apartment
    }

    void doorOpeningSfx()
    {
        Debug.Log("play sfx");
        AudioSource.PlayClipAtPoint(doorSfx, gameObject.transform.position, 0.5f);
    }

    IEnumerator getTheFood()
    {
        AudioSource.PlayClipAtPoint(doorBellSfx, gameObject.transform.position, 1f);
        yield return new WaitForSeconds(1f);
    }
}
