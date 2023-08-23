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
/// Creates a damage flash effect on enemys by changing their material.
/// </summary>
public class DamageFlash : MonoBehaviour, IDMGFlash
{
    [SerializeField] MeshRenderer[] mMeshRenderers;
    [SerializeField] Material mMaterial, mDmgMaterial;
    [SerializeField] float mFlashDuration = 0.05f;

    public void FlashEnemy()
    {
        foreach (MeshRenderer meshRenderer in mMeshRenderers)
            meshRenderer.material = mDmgMaterial;
        Invoke("ResetMaterial", mFlashDuration);
    }
    void ResetMaterial()
    {
        foreach (MeshRenderer meshRenderer in mMeshRenderers)
            meshRenderer.material = mMaterial;
    }
}
