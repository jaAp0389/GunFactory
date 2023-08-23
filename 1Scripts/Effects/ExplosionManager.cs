/*****************************************************************************
* Project: GunFactory
* File   : ExplosionManager.cs
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
using UnityEngine;

public class ExplosionManager : MonoBehaviour
{
    //[SerializeField] ParticleSystem mExplosion;
    [SerializeField] float mLifetime;
    private void Awake()
    {
        Destroy(gameObject, mLifetime);
    }
}
