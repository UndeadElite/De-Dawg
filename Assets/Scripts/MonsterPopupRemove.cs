using UnityEngine;

public class MonsterPopupRemove : MonoBehaviour
{
    [SerializeField] GameObject monsterGameObject;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            monsterGameObject.SetActive(false);
        }
    }
}
