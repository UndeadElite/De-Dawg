using UnityEngine;

public class PlayerBarkDetection : MonoBehaviour
{
    public bool playerInCollider = false;

    [SerializeField] Door doorScript;
    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            playerInCollider = true;
            doorScript.doorBell = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.gameObject.CompareTag("Player"))
        {
            playerInCollider = false;
        }
    }
}