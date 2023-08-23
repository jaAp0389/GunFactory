/*****************************************************************************
* Project: GunFactory
* File   : AnimationStarterWithInterfaceTrigger.cs
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
*   23.08.2021	JA	Created
******************************************************************************/
using UnityEngine;

/// <summary>
/// Randomizes animation speed of gameobject on awake. I made this so floating
/// pickups don't move in unison.
/// </summary>
public class AnimationDeferred : MonoBehaviour
{
    Animator mAnimator;

    private void Awake()
    {
        mAnimator = gameObject.GetComponent<Animator>();
        mAnimator.speed += (Random.value - 0.5f);
    }
}
