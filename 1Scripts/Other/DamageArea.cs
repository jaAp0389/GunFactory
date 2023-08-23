/*****************************************************************************
* Project: GunFactory
* File   : DamageArea.cs
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
*   15.08.2021	JA	Created
******************************************************************************/
using UnityEngine;

/// <summary>
/// Class for player damaging trigger areas. 
/// </summary>
public class DamageArea : MonoBehaviour, ITrigger
{
    [SerializeField] private float damage;
    [SerializeField] private float damageInterval;
    AudioSource mSizzle;
    private bool canDamage = true;
    public void TriggerEnter(Collider other) { }
    public void TriggerExit(Collider other) 
    {
        mSizzle?.Stop();
    }
    public void TriggerStay(Collider other)
    {
        if(canDamage)
        {
            IHealth health = other.GetComponent<IHealth>();

            mSizzle?.Play();
            health?.ChangeHealth(damage);
            canDamage = false;

            Invoke("SetDamageTrue", damageInterval * Time.deltaTime * 20);

        }
    }
    private void SetDamageTrue()
    {
        canDamage = true;
    }
}
