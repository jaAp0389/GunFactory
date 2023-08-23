/*****************************************************************************
* Project: GunFactory
* File   : Pickupable.cs
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
/// Pickup action class. Unifys OnTriggercall i guess. If i had more modular 
/// pickupeffect classes this would make sense.
/// </summary>
[RequireComponent(typeof(Collider))]
public class Pickupable : MonoBehaviour
{
    IPickupAction pickupAction;
    void Awake()
    {
        pickupAction = gameObject.GetComponent<IPickupAction>();
    }
    private void OnTriggerEnter(Collider other)
    {
        pickupAction?.OnPickup(other.gameObject);
    }
}
