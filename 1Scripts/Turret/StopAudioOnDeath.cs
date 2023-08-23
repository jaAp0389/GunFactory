/*****************************************************************************
* Project: GunFactory
* File   : StopAudioOnDeath.cs
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
*   25.08.2021	JA	Created
******************************************************************************/
using UnityEngine;

/// <summary>
/// Class for audio that needs to stop on death. called by healthinfo.
/// </summary>
public class StopAudioOnDeath : MonoBehaviour, IDeath
{
    [SerializeField] AudioSource mAudioSource;
    public void StartUntilDeathAudio()
    {
        mAudioSource.Play();
    }
    public void OnDeath()
    {
        mAudioSource.Stop();
    }
}
