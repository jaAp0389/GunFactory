/*****************************************************************************
* Project: GunFactory
* File   : LazyFunction.cs
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
*   25.08.2021	JA	Created
******************************************************************************/
using UnityEngine;
/// <summary>
/// For Some class that is used on different prefabs which expects a call target
/// and it was more complicated to change that.
/// </summary>
public class LazyFunction : MonoBehaviour
{
    public void StartResetTimer()
    {
        //doesn't start resettimer
    }
}
