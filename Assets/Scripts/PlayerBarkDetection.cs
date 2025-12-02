using UnityEngine;

public class PlayerBarkDetection : MonoBehaviour
{
    public bool playerInCollider = false;

    [SerializeField] Door doorScript;
    public void OnTriggerStay(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            playerInCollider = true;
            doorScript.doorBell = true;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (!other.gameObject.CompareTag("Player"))
        {
            playerInCollider = false;
        }
    }
}