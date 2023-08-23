/*****************************************************************************
* Project: GunFactory
* File   : ScreenColorBurst.cs
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
/// For easing into and out of color.
/// </summary>
public class ScreenColorBurst : MonoBehaviour, IBurstColor
{
    [SerializeField] Color mColor;
    [SerializeField] float mChangeAmount = 0.1f;
    [SerializeField] Image mColorOverlay;
    public float MTransparencyChange { set { mChangeAmount = value; } }
    public Color MColor { set { mColor = value; } }

    public void DoColorBurst(float _intensity)
    {
        StopAllCoroutines();
        StartCoroutine(ColorBurst(_intensity));
    }
    IEnumerator ColorBurst(float _targetTransparency)
    {
        float targetTransparency = _targetTransparency;
        float changeAmount = mChangeAmount * targetTransparency;
        if (mColor.a > targetTransparency) targetTransparency = 0f;
        for (int i = 0; i < 2; i++)
        {
            while (mColor.a != targetTransparency)
            {
                if (mColor.a < targetTransparency)
                    if (mColor.a + changeAmount > targetTransparency)
                        mColor.a = targetTransparency;

                    else mColor.a += changeAmount;

                else
                {
                    if (mColor.a - changeAmount < 0f) mColor.a = 0f;

                    else mColor.a -= changeAmount;
                }
                mColorOverlay.color = mColor;
                yield return new WaitForSeconds(Time.deltaTime);
            }
            targetTransparency = 0f;
        }
        //-\/some persistent colorbug which happened once and i can't reproduce.
        if (mColor.a != 0f) mColor.a = 0f; 
    }
}
