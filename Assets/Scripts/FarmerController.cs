using UnityEngine;
using UnityEngine.Audio;

public class FarmerController : MonoBehaviour
{
    private Animator animator;
    private AudioSource audioSource;

    public AudioClip introAudio; // 👈 assign in Inspector
    public AudioClip infoAudio; // 👈 assign in Inspector
    public GameObject talkingIndicator; // 👈 assign in Inspector

    void Awake()
    {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayVoice(AudioClip clip)
    {
        if (clip != null && audioSource != null)
        {
            audioSource.Stop(); // stop any current voice
            HideIndicator();
            audioSource.clip = clip;
            audioSource.Play();

            if (talkingIndicator != null)
            {
                talkingIndicator.SetActive(true);
                Invoke(nameof(HideIndicator), clip.length);
            }
        }
    }

    public void PlayWave()
    {
        animator.Play("waveAnimation"); // Make sure this matches the animation clip name
        PlayVoice(introAudio);
    }

    public void PlayIdle()
    {
        animator.Play("IdleAnimation"); // Make sure this matches the animation clip name
    }

    void HideIndicator()
    {
        if (talkingIndicator != null)
        {
            talkingIndicator.SetActive(false);
        }
    }

    public void PlayInfoSpeech()
    {
        PlayVoice(infoAudio);
    }
}
