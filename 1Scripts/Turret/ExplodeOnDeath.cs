/*****************************************************************************
* Project: GunFactory
* File   : DamageFlash.cs
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
*   20.08.2021	JA	Created
******************************************************************************/
using UnityEngine;

/// <summary>
/// Handles playing of explosion on death effect.
/// </summary>
public class ExplodeOnDeath : MonoBehaviour, IDeath
{
    [SerializeField] ParticleSystem[] mParticleSystems;
    [SerializeField] AudioSource mSoundExplosion;
    [SerializeField] MultipleExplosionsHandler mMultipleExplosionsHandler;
    public void OnDeath()
    {
        if(mParticleSystems!=null)
        {
            mSoundExplosion?.Play();
            foreach (ParticleSystem particleSystem in mParticleSystems)
                particleSystem.Play();
        }
        if (mMultipleExplosionsHandler != null)
            mMultipleExplosionsHandler.PlayExplosions();



    }
    public void OnRevive()
    {
        if (mParticleSystems != null)
            foreach (ParticleSystem particleSystem in mParticleSystems)
                particleSystem.Stop();
    }
}
