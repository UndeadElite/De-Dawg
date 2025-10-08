using UnityEngine;
using System.Collections;

public class SongChange : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip firstSong;
    [SerializeField] AudioClip songToChangeTo;
    [SerializeField] float volume = 1f;
    [SerializeField] float reTriggerDelay = 1f;
    [SerializeField] bool reTrigger;

    bool canTrigger = true;
    bool playFirst = true;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && canTrigger)
        {
            canTrigger = false;

            if (!reTrigger)
            {
                audioSource.Stop();
                audioSource.clip = songToChangeTo;
                audioSource.loop = false;
                audioSource.Play();
            }
            else
            {
                AudioClip nextClip = playFirst ? songToChangeTo : firstSong;
                playFirst = !playFirst;
                StartCoroutine(SwitchSong(nextClip));
                Invoke(nameof(ResetTrigger), reTriggerDelay);
            }
        }
    }

    IEnumerator SwitchSong(AudioClip newClip)
    {
        float startVol = audioSource.volume;
        while (audioSource.volume > 0f)
        {
            audioSource.volume -= startVol * Time.deltaTime;
            yield return null;
        }
        audioSource.Stop();
        audioSource.clip = newClip;
        audioSource.volume = startVol;
        audioSource.Play();
    }

    void ResetTrigger()
    {
        canTrigger = true;
    }
}
