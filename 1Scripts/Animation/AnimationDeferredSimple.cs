/*****************************************************************************
* Project: GunFactory
* File   : AnimationDeferredSimple.cs
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
/// Same as AnimationDeffered with a "simpler" Audiosource instead of an animator
/// </summary>
public class AnimationDeferredSimple : MonoBehaviour
{
    [SerializeField] float mStarTime = -1;
    Animation mAnim;
    private void Awake()
    {
        mAnim = gameObject.GetComponent<Animation>();
        Invoke("PlayAnim", mStarTime < 0 ? Random.value * 2 : mStarTime);
    }
    void PlayAnim()
    {
        mAnim.Play();
    }
}
