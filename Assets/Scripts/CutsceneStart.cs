using UnityEngine;
using UnityEngine.Timeline;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(SignalReceiver))] 
public class CutsceneStart : MonoBehaviour
{
    [SerializeField] private GameObject cutsceneToPlay;
    public AudioSource songAudioSource;
    public void Activate()
    {
        PlayerControllerManager.Instance.CutsceneCamera.SetActive(true);
        PlayerControllerManager.Instance.CutscenePlayerCamera.SetActive(true);
        PlayerControllerManager.Instance.FirstPersonCamera.SetActive(false);
        songAudioSource.enabled = false;
    }

    public void Deactivate()
    {
        PlayerControllerManager.Instance.CutsceneCamera.SetActive(false);
        PlayerControllerManager.Instance.CutscenePlayerCamera.SetActive(false);
        PlayerControllerManager.Instance.FirstPersonCamera.SetActive(true);

        NightManager.currentNight++;
        SceneManager.LoadScene("Night" + NightManager.currentNight);
        Debug.Log("Night" + NightManager.currentNight);
    }
}
