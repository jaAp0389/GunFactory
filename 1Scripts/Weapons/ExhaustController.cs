/*****************************************************************************
* Project: GunFactory
* File   : ExhaustController.cs
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
*   23.08.2021	JA	Created
******************************************************************************/
using System.Collections;
using UnityEngine;
/// <summary>
/// Plays Exhaust particles on playergun. Playing time is the time the player 
/// shot the weapon with a min and max clamp.
/// </summary>
public class ExhaustController : MonoBehaviour
{
    [SerializeField] ParticleSystem[] mExhausts;
    [SerializeField] AudioSource mExhaustAudio;
    [SerializeField] float mExhaustTimeMax = 2;
    [SerializeField] float mExhaustTimeMin = 0.3f;
    [SerializeField] float mExhaustTime = 0;
    float mTimeStarted;
    bool isTimerRunning = false;

    public void PlayParticle(float _time)
    {
        mExhaustTime = Mathf.Clamp(mExhaustTime + _time, 0, mExhaustTimeMax);
        if (mExhaustTime < mExhaustTimeMin) return;
        foreach(ParticleSystem particle in mExhausts)
        {
            particle.Play();
        }
        mExhaustAudio.Play();
        StartTimer(mExhaustTime);
    }
    public void StopParticle()
    {
        if (isTimerRunning) StopTimer();
        foreach (ParticleSystem particle in mExhausts)
            particle.Stop();
        mExhaustAudio.Stop();
    }
    void StartTimer(float _waitForSeconds)
    {
        isTimerRunning = true;
        mTimeStarted = Time.time;
        StartCoroutine(WaitAndStop(_waitForSeconds));
    }
    void StopTimer()
    {
        isTimerRunning = false;
        mExhaustTime = mExhaustTime - (Time.time - mTimeStarted);
        StopAllCoroutines();
    }
    IEnumerator WaitAndStop(float _waitForSeconds)
    {
        yield return new WaitForSeconds(_waitForSeconds);

        mExhaustTime = 0;
        isTimerRunning = false;
        StopParticle();
    }
}
