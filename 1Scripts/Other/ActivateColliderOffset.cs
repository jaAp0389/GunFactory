/*****************************************************************************
* Project: GunFactory
* File   : ActivateColliderOffset.cs
* Date   : 27.08.2021
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

public class ActivateColliderOffset : MonoBehaviour
{
    [SerializeField] Collider mCollider;
    private void Awake()
    {
        Invoke("ActivateCollider", 0.1f);
    }
    void ActivateCollider()
    {
        mCollider.enabled = true;
    }
}
