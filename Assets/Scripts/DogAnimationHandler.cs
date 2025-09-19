using StarterAssets;
using UnityEngine;

public class DogAnimationHandler : MonoBehaviour
{
    Animator dogAnimator;

    GiveFood giveFood;

    private void Start()
    {
        giveFood = FindFirstObjectByType<GiveFood>();
        dogAnimator = GetComponentInParent<Animator>();
    }
    void OnTriggerStay(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Start barking");
            if (giveFood.HaveIGivenFood)
            {
                Debug.Log("Stop Barking - food given");

            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Stop barking");
        }
    }
}
