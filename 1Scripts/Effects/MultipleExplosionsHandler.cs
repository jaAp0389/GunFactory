/*****************************************************************************
* Project: GunFactory
* File   : MultipleExplosionsHandler.cs
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
*   24.08.2021	JA	Created
******************************************************************************/
using System.Collections;
using UnityEngine;

/// <summary>
/// Plays an particle array with offset time
/// </summary>
public class MultipleExplosionsHandler : MonoBehaviour
{
    [SerializeField] ParticleSystem[] mExplosionParticles;
    [SerializeField] AudioSource[] mExplosionAudios;
    [SerializeField] float mExplosionOffset;

    public void PlayExplosions()
    {
        StartCoroutine(PlayExplosionsOffsetted());
    }
    IEnumerator PlayExplosionsOffsetted()
    {
        for(int i =0; i < mExplosionParticles.Length; i++)
        {
            mExplosionParticles[i].Play();
            mExplosionAudios[i].Play();
            yield return new WaitForSeconds(mExplosionOffset);
        }
    }
}
