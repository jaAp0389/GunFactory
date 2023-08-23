/*****************************************************************************
* Project: GunFactory
* File   : AnimationStarterWithInterface.cs
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
/// Starts Animations with a IAnimation interface. I needed this for a gameobject 
/// which already had iactions which needed to be called independently
/// </summary>
public class AnimationStarterWithInterface : MonoBehaviour, IAnimationStart
{
    [SerializeField] Animation mAnimation;
    public void StartAnimation()
    {
        mAnimation.Play();
    }
}
