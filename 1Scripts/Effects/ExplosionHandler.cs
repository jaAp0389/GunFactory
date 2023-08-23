/*****************************************************************************
* Project: GunFactory
* File   : ExplosionHandler.cs
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
/// Class for area of effect damaging explosions.
/// </summary>
public class ExplosionHandler : MonoBehaviour
{

    [SerializeField] float mDamage = -10;
    [SerializeField] float mRange = 5;

    private void Awake()
    {
        Collider[] colliderInRange = 
            Physics.OverlapSphere(transform.position, mRange);

        foreach(Collider collider in colliderInRange)
        {
            IHealth health = collider.gameObject.GetComponent<IHealth>();
            health?.ChangeHealth(mDamage);

            ///could be in the changehealth call but i wanted to keep things 
            ///modular because maybe i want an enemy that doesn't flash when 
            ///it gets damaged. (i don't)
            IDMGFlash dMGFlash = collider.gameObject.GetComponent<IDMGFlash>();
            dMGFlash?.FlashEnemy();
        }
    } 
}
