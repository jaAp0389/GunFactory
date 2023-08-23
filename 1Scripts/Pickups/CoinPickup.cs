/*****************************************************************************
* Project: GunFactory
* File   : CoinPickup.cs
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
*   19.08.2021	JA	Created
******************************************************************************/
using UnityEngine;

/// <summary>
/// Manages coin item
/// </summary>
public class CoinPickup : MonoBehaviour, IPickupAction
{
    [SerializeField] AudioSource mCoinSound;
    [SerializeField] MeshRenderer mMeshRenderer;
    bool pickedUp;
    public void OnPickup(GameObject _target)
    {
        if (pickedUp) return;
        mCoinSound.Play();
        mMeshRenderer.enabled = false;
        _target.GetComponent<IMoney>()?.ChangeMoney(1);
        Destroy(gameObject, 2f);
        pickedUp = true;
    }
}
