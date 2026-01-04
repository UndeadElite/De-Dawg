using UnityEngine;

public class MonsterPopup : MonoBehaviour
{
    [SerializeField] GameObject monsterGameObject;
    [SerializeField] GameObject removeMonsterCollider;
    [SerializeField] GameObject violinStinger;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            monsterGameObject.SetActive(true);
            removeMonsterCollider.SetActive(true);
            violinStinger.SetActive(true);
        }
    }
}
