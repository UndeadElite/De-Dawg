using UnityEngine;

public class HandSaw : MonoBehaviour, IInteractable
{
    [SerializeField] private GameObject handSawCutscene;
    [SerializeField] CutsceneStart cutsceneStart;
    [SerializeField] ResetCamera resetCamera;
    public Camera mainCamera;
    public void Interact()
    {
        //play cutscene
        resetCamera.CacheCamera(mainCamera);
        handSawCutscene.SetActive(true);
        cutsceneStart.Activate();
    }
}
