/*****************************************************************************
* Project: GunFactory
* File   : ChangeToCorpse.cs
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
/// Handles turret corpse effect. Turns off turret and turns on copy of turret 
/// with black material. It's easier because that way i don't have to deactivate 
/// all the scripts on the turret.
/// </summary>
public class ChangeToCorpse : MonoBehaviour, IDeath
{
    [SerializeField] GameObject mTurret;
    [SerializeField] GameObject mCorpse;
    [SerializeField] Transform[] mTurretGimbals, 
                                 mCorpseGimbals;
    [SerializeField] Collider[] mColliders;
    public void OnDeath()
    {
        foreach(Collider coll in mColliders)
            coll.enabled = false;
        mCorpse.SetActive(true);
        SetGimbals();
        mTurret.SetActive(false);
    }
    public void Revive()
    {
        foreach (Collider coll in mColliders)
            coll.enabled = true;
        mCorpse.SetActive(false);
        mTurret.SetActive(true);
    }

    void SetGimbals()
    {
        for(int i = 0; i < mTurretGimbals.Length; i++)
        {
            mCorpseGimbals[i].rotation = mTurretGimbals[i].rotation;
        }
    }
}
