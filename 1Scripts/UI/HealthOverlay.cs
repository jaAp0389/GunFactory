/*****************************************************************************
* Project: GunFactory
* File   : HealthOverlay.cs
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
*   18.08.2021	JA	Created
******************************************************************************/
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Extra ui screen color burst for picking up healthpotion.
/// </summary>
public class HealthOverlay : MonoBehaviour
{
    [SerializeField] Color mColor;
    [SerializeField] float mTargetTransparency = 0.5f;
    [SerializeField] float mTransparencyChange = 0.1f;
    Image mImage;

    private void Awake()
    {
        mImage = gameObject.GetComponent<Image>();
    }

    public void FadeIntoColor()
    {
        StopAllCoroutines();
        StartCoroutine(ColorBurst(mTargetTransparency));
    }

    IEnumerator ColorBurst(float _targetTransparency)
    {
        float targetTransparency = _targetTransparency;
        for (int i = 0; i < 2; i++)
        {
            while (mColor.a != targetTransparency)
            {
                if (Mathf.Abs(mColor.a - targetTransparency) <
                        mTransparencyChange)// || mColor.a < 0f)
                {
                    mColor.a = targetTransparency;
                    continue;
                }

                if (mColor.a < targetTransparency) mColor.a += mTransparencyChange;
                else mColor.a -= mTransparencyChange;

                mImage.color = mColor;
                yield return new WaitForFixedUpdate();
            }
            targetTransparency = 0f;
        }
    }
}
