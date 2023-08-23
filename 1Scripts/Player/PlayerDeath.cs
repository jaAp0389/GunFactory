/*****************************************************************************
* Project: GunFactory
* File   : PlayerDeath.cs
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
*   27.08.2021	JA	Created
******************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    [SerializeField] ScreenColorWithCall mScreenColorWithCall;
    [SerializeField] AudioSource mPlayerDeathAudio;
    [SerializeField] Animation mPlayerDeathAnimation;
    [SerializeField] GameObject mHGameUi;
    [SerializeField] GameObject mPauseMenu;

    public void Death()
    {
        Cursor.lockState = CursorLockMode.None;
        mHGameUi.SetActive(false);
        mPauseMenu.SetActive(false);
        if(mPlayerDeathAudio!=null) mPlayerDeathAudio.Play();
        if (mPlayerDeathAnimation != null) mPlayerDeathAnimation.Play();
        mScreenColorWithCall.FadeIntoColor();
    }
}
