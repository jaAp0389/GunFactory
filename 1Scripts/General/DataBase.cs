/*****************************************************************************
* Project: GunFactory
* File   : DataBase.cs
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
*   05.08.2021	JA	Created
******************************************************************************/
using UnityEngine;

/// <summary>
/// unused. Serializing a Gameobject is complicated. I just made a 
/// findwithTag (player) call on the classes instead because i didn't 
/// want to set it manually each time. I will do this properly the next time.
/// </summary>
public class DataBase : MonoBehaviour
{
    [SerializeField] GameObject mPlayer;
    static public GameObject MPlayer { get; }

    [SerializeField] GameObject mCamera;
    static public GameObject MCamera { get; }
}
