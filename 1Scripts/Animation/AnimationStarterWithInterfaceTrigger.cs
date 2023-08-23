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
*   26.08.2021	JA	Created
******************************************************************************/
using UnityEngine;

/// <summary>
/// Trigger Relay for animationStarterInterface
/// </summary>
public class AnimationStarterWithInterfaceTrigger : MonoBehaviour
{
    [SerializeField] GameObject mTarget;
    IAnimationStart mIAnimationStart;
    private void Awake()
    {
        mIAnimationStart = mTarget.GetComponent<IAnimationStart>();
    }
    private void OnTriggerEnter(Collider other)
    {
        mIAnimationStart.StartAnimation();
        Destroy(gameObject);
    }
}
