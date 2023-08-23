/*****************************************************************************
* Project: GunFactory
* File   : HealthInfoRelay.cs
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
using UnityEngine;

/// <summary>
/// For Turretparts with their own colliders. Relay damage to the main
/// turretcontainer.
/// </summary>
public class HealthInfoRelay : MonoBehaviour, IHealth, IDMGFlash
{
    [SerializeField] HealthInfo mHealthInfo;
    [SerializeField] DamageFlash mDamageFlash;

    public void ChangeHealth(float cHealth)
    {
        mHealthInfo.ChangeHealth(cHealth);
    }
    public void FlashEnemy()
    {
        mDamageFlash.FlashEnemy();
    }
}
