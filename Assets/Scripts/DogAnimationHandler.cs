using UnityEngine;

public class DogAnimationHandler : MonoBehaviour
{
    Animator dogAnimator;
    [SerializeField] GameObject barkSfxLocation;
    [SerializeField] Door doorScript;

    public AudioClip[] barkSfxs;

    GiveFood giveFood;
    PlayerBarkDetection playerBarkDetection;
    private void Start()
    {
        playerBarkDetection = GetComponentInChildren<PlayerBarkDetection>();
        giveFood = GetComponent<GiveFood>();
        giveFood = FindFirstObjectByType<GiveFood>();
        dogAnimator = GetComponentInParent<Animator>();
        dogAnimator.SetBool("isEating", false);
    }

    private void Update()
    {
        if (playerBarkDetection.playerInCollider)
        {
            dogAnimator.SetBool("playerNear", true);

            if (giveFood.HaveIGivenFood)
            {
                dogAnimator.SetBool("isEating", true);
            }
        }
        else
        {
            dogAnimator.SetBool("playerNear", false);
        }
    }

    void PlayBarkSfx()
    {
        //create a randomized bark clip
        AudioSource.PlayClipAtPoint(barkSfxs[UnityEngine.Random.Range(0, barkSfxs.Length)], barkSfxLocation.transform.position, 0.3f);
    }
}
