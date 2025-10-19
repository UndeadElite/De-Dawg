using UnityEngine;

public class PlayerBarkDetection : MonoBehaviour
{
    public bool playerInCollider = false;

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            Debug.Log("player is in");
            playerInCollider = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.gameObject.CompareTag("Player"))
        {
            Debug.Log("player left");
            playerInCollider = false;
        }
    }
}
