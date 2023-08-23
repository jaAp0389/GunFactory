/*****************************************************************************
* Project: GunFactory
* File   : HealthPickup.cs
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
/// Class to manage the Healthpickup.
/// </summary>
public class HealthPickup : MonoBehaviour, IPickupAction
{
    [SerializeField] float mHealValue;
    [SerializeField] GameObject mPickupEffect;
    //[SerializeField] GameObject mPickupModel;
    //[SerializeField] Collider mCollider;
    HealthOverlay mHealthOverlay;
    private void Awake()
    {
        mHealthOverlay = GameObject.Find("HealthOverlay").
            GetComponent<HealthOverlay>();
    }
    public void OnPickup(GameObject target)
    {
        IHealth health = target.GetComponent<IHealth>();
        if (health != null)
        {
            health.ChangeHealth(mHealValue);
            mHealthOverlay.FadeIntoColor();
            RemovePickup();
        }
    }
    void RemovePickup()
    {
        if (mPickupEffect != null)
        {
            GameObject pickupEffect = Instantiate(mPickupEffect, transform);
            pickupEffect.transform.parent = null;
        }
        Destroy(gameObject);
        //play pickup sound
        //Destroy(mPickupModel);
        //mCollider.enabled = false;
    }
}
