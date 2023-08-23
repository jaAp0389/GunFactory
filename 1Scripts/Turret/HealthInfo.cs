/*****************************************************************************
* Project: GunFactory
* File   : HealthInfo.cs
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
*   17.08.2021	JA	Created
******************************************************************************/
using UnityEngine;

/// <summary>
/// Turret Health Class. Target for Buillets by IHealth interface. Sends Death 
/// Event when Health is 0.
/// </summary>
public class HealthInfo : MonoBehaviour, IHealth
{
    [SerializeField] GameObject mOnDeathExtra;
    [SerializeField] float mHealth;
    public bool isAlive { get; set; } = true;
    public float MHealth { get { return mHealth; } private set { } }
    IDeath[] iDeaths;
    IDeath mIDeathExtra;

    private void Awake()
    {
        if(mOnDeathExtra!=null) mIDeathExtra = 
                mOnDeathExtra.GetComponent<IDeath>();
        iDeaths = gameObject.GetComponents<IDeath>();
    }
    public void ChangeHealth(float cHealth)
    {
        mHealth += cHealth;
        if (mHealth <= 0 && isAlive) 
        {
            Die();
            isAlive = false;
        }
    }
    void Die()
    {
        mIDeathExtra?.OnDeath();
        if (iDeaths!=null)
        {
            foreach(IDeath iDeath in iDeaths)
                iDeath.OnDeath();
        }
        else Destroy(gameObject);
    }
}

