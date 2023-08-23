/*****************************************************************************
* Project: GunFactory
* File   : SetGameObjectSimple.cs
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
*   22.08.2021	JA	Created
******************************************************************************/
using UnityEngine;

/// <summary>
/// Sets Gameobjects activation state by animation event and can be turned off.
/// </summary>
public class SetGameObjectSimple : MonoBehaviour
{
    [SerializeField] GameObject[] mObjects;
    [SerializeField] bool mIsActivate, mTurnOff;

    public void SetGameObject()
    {
        if(!mTurnOff) 
            foreach(GameObject _object in mObjects)
                _object.SetActive(mIsActivate);
    }
}
