using UnityEngine;
using UnityEngine.Timeline;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(SignalReceiver))] 
public class CutsceneStart : MonoBehaviour
{
    public bool nextNight = false;

    [SerializeField] private GameObject cutsceneToPlay;
    public AudioSource songAudioSource;
    public GameObject screenText;
    [SerializeField] public PickUp pickUp;
    public void Activate()
    {
        PlayerControllerManager.Instance.CutsceneCamera.SetActive(true);
        PlayerControllerManager.Instance.CutscenePlayerCamera.SetActive(true);
        PlayerControllerManager.Instance.FirstPersonCamera.SetActive(false);
        songAudioSource.enabled = false;
        screenText.SetActive(false);
    }

    public void Deactivate()
    {
        PlayerControllerManager.Instance.CutsceneCamera.SetActive(false);
        PlayerControllerManager.Instance.CutscenePlayerCamera.SetActive(false);
        PlayerControllerManager.Instance.FirstPersonCamera.SetActive(true);
        screenText.SetActive(true);

        if (nextNight)
        {
            NightManager.CurrentNight++;
            SceneManager.LoadScene("Night" + NightManager.CurrentNight);
            Debug.Log("Night" + NightManager.CurrentNight);
        }
    }

    public void PickUpBool()
    {
        pickUp.DoIHaveFood = true;
    }
}
