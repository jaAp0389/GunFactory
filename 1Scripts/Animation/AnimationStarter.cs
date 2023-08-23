/*****************************************************************************
* Project: GunFactory
* File   : AnimationStarter.cs
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
/// Starts Animation by IAction Call
/// </summary>
public class AnimationStarter : MonoBehaviour, IAction
{
    [SerializeField] Animation mAnimation;
    [SerializeField] string[] mAnimationStrings;
    int mAnimationIndex = 0;

    public void ExecuteAction()
    {
        mAnimation.Play(mAnimationStrings[mAnimationIndex]);
        mAnimationIndex++;
        if (mAnimationIndex > mAnimationStrings.Length - 1) mAnimationIndex = 0;
    }
}
