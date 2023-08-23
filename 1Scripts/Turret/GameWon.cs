/*****************************************************************************
* Project: GunFactory
* File   : GameWon.cs
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

public class GameWon : MonoBehaviour,IDeath
{
    [SerializeField] GameObject mGameEndMenu;
    [SerializeField] PlayerDeath mPlayerDeath;
    [SerializeField] float mEndGameTime = 5f;

    public void OnDeath()
    {
        Invoke("EndGame", mEndGameTime);
    }

    void EndGame()
    {
        mGameEndMenu.SetActive(true);
        mPlayerDeath.Death();
    }
}
