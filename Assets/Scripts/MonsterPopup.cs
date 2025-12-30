using UnityEngine;

public class MonsterPopup : MonoBehaviour
{
    [SerializeField] GameObject monsterGameObject;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            monsterGameObject.SetActive(true);
        }
    }
}
