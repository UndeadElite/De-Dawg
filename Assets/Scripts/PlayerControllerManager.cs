using StarterAssets;
using UnityEngine;

public class PlayerControllerManager : MonoBehaviour
{
    public static PlayerControllerManager Instance;
    [SerializeField] FirstPersonController firstPersonController;
    [SerializeField] GameObject playerModel;

    private void Awake()
    {
        Instance = this;
    }

    public void Activate()
    {
        firstPersonController.enabled = true;
        playerModel.SetActive(true);
    }

    public void Deactivate()
    {
        firstPersonController.enabled = false;
        playerModel.SetActive(false);
    }
}
