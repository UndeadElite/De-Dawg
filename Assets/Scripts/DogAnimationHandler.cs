using StarterAssets;
using UnityEngine;

public class DogAnimationHandler : MonoBehaviour
{
    Animator dogAnimator;

    GiveFood giveFood;

    private void Start()
    {
        giveFood = GetComponent<GiveFood>();
        giveFood = FindFirstObjectByType<GiveFood>();
        dogAnimator = GetComponentInParent<Animator>();
        dogAnimator.SetBool("isEating", false);
    }
    void OnTriggerStay(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            dogAnimator.SetBool("playerNear", true);
            Debug.Log("Start barking");
            if (giveFood.HaveIGivenFood)
            {
                dogAnimator.SetBool("isEating", true);
                Debug.Log("Stop Barking - food given");
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            dogAnimator.SetBool("playerNear", false);
            Debug.Log("Stop barking");
        }
    }
}
