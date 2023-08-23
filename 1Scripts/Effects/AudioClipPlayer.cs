/*****************************************************************************
* Project: GunFactory
* File   : AudioClipPlayer.cs
* Date   : 26.08.2021
* Author : Jan Apsel (JA)
*
* These coded instructions, statements, and computer programs contain
* proprietary information of the author and are protected by Federal
* copyright law. They may not be disclosed to third parties or copied
* or duplicated in any form, in whole or in part, without the prior
* written consent of the author.
*
* History:
*   27.08.2021	JA	Created
******************************************************************************/
using UnityEngine;

/// <summary>
/// For playing AudioClips. Also has a random Chance not to play clip and has 
/// a delay between playing clips. 
/// </summary>
public class AudioClipPlayer : MonoBehaviour
{
    [SerializeField] AudioClip[] mAudioClips;
    [SerializeField] AudioSource mAudioSource;
    bool isTimerDone = true;

    public void PlayRandomAudioClip(float _mAudioPlayChance)
    {
        if (!isTimerDone) return;

        if(Random.value > _mAudioPlayChance)
            mAudioSource.PlayOneShot
                (mAudioClips[Random.Range(0, mAudioClips.Length)]);

        Invoke("SetTimerTrue", 1f);
        isTimerDone = false;
    }
    void SetTimerTrue() => isTimerDone = true;
}