/*****************************************************************************
* Project: GunFactory
* File   : AnimationToggle.cs
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
/// Toggles Animations by iaction call
/// </summary>
public class AnimationToggle : MonoBehaviour, IAction
{
    [SerializeField] Animator mAnimator;
    bool isForward = true;
    public void ExecuteAction()
    {
        mAnimator.SetBool("isForward", isForward);
        isForward = !isForward;
    }
}
