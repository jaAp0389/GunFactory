/*****************************************************************************
* Project: GunFactory
* File   : PlayerAddition.cs
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
*   18.08.2021	JA	Created
******************************************************************************/
using UnityEngine;

/// <summary>
/// Additional player behaviour.
/// </summary>
public class PlayerAddition : MonoBehaviour
{
    //[SerializeField] GunController mGunController;
    IGun mIGun;
    IMouseTimer mMouseTimer;

    float mStartTime;

    private void Awake() => GetReferences();
    void GetReferences()
    {
        mIGun = GetComponentInChildren<IGun>();
        mMouseTimer = GetComponentInChildren<IMouseTimer>();
    }
    void Update()
    {
        if (Input.GetButton("Fire1"))
            mIGun?.Shoot();
        if (Input.GetButtonDown("Fire1"))
            mStartTime = Time.time;
        if (Input.GetButtonUp("Fire1"))
            mMouseTimer?.GetMouse1Time(Time.time - mStartTime);
    }
}
