using UnityEngine;

/// <summary>
/// For toggling audio by animation event
/// </summary>
public class AudioToggle : MonoBehaviour
{
    [SerializeField] AudioSource mAudioSource;

    public void PlayAudio()
    {
        mAudioSource.Play();
    }
    public void StopAudio()
    {
        mAudioSource.Stop();
    }
}
