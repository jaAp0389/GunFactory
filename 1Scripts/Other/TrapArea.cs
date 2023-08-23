/*****************************************************************************
* Project: GunFactory
* File   : TrapArea.cs
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
*   17.08.2021	JA	Created
******************************************************************************/
using System.Collections;
using UnityEngine;

/// <summary>
/// Class to manage animated traps/ the spiketrap. Has a wait time so the damage 
/// happens when the spikes are extended, not immediatly.
/// </summary>
public class TrapArea : MonoBehaviour, IAction
{
    [SerializeField] float mDamage = -10f, mWaitTime = 0.1f;
    [SerializeField] AudioSource mStabAudio;
    Animation mAnimation;
    bool isDisabled = false;

    void Awake()
    {
        mAnimation = GetComponentInChildren<Animation>();
    }
    public void ExecuteAction() => isDisabled = false;
    private void OnTriggerStay(Collider other)
    {
        if (isDisabled) return;
        IHealth health = other.gameObject.GetComponent<IHealth>();
        if (health != null)
        {
            isDisabled = true;
            SpringTrap();
            StartCoroutine(DoDamage(health));
        }
    }
    IEnumerator DoDamage(IHealth _target)
    {
        yield return new WaitForSeconds(mWaitTime * Time.deltaTime * 20);
        _target.ChangeHealth(mDamage);
    }
    void SpringTrap()
    {
        mAnimation?.Play();
        mStabAudio?.Play();
    }
}
