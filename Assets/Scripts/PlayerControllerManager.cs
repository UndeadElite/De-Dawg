using StarterAssets;
using UnityEngine;

public class PlayerControllerManager : MonoBehaviour
{
    public static PlayerControllerManager Instance;
    [SerializeField] FirstPersonController firstPersonController;
    [SerializeField] GameObject playerModel;

    public GameObject FirstPersonCamera; //Player's pov
    public GameObject CutsceneCamera; //Cutscene with a brain
    public GameObject CutscenePlayerCamera; //Cutscene from the player's pov
    private void Awake()
    {
        Instance = this;

        PlayerControllerManager.Instance.CutsceneCamera.SetActive(false);
        PlayerControllerManager.Instance.CutscenePlayerCamera.SetActive(false);
        PlayerControllerManager.Instance.FirstPersonCamera.SetActive(true);
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
