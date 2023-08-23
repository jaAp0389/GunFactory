/*****************************************************************************
* Project: GunFactory
* File   : ScreenColor.cs
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
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Class fading in and out of a screenfilling color UI element.
/// </summary>
public class ScreenColor : MonoBehaviour, ITrigger
{
    [SerializeField] private Color mColor;
    [SerializeField] private float mTargetTransparency = 0.5f;
    [SerializeField] private float mTransparencyChange = 0.1f;
    public float MTargetTransparency { set { mTargetTransparency = value; } }
    public float MTransparencyChange { set { mTransparencyChange = value; } }
    public Color MColor { set { mColor = value; } }
    private Image mColorOverlay;

    private void Awake()
    {
        mColorOverlay = GameObject.
            FindGameObjectWithTag("AreaOverlay").GetComponent<Image>();
    }

    public void TriggerEnter(Collider other)
    {
        FadeIntoColor();
    }
    public void TriggerExit(Collider other) 
    {
        FadeOutOfColor();
    }
    public void TriggerStay(Collider other) { }

    void FadeIntoColor()
    {
        StopAllCoroutines();
        StartCoroutine(ChangeTransparency(mTargetTransparency));
    }
    void FadeOutOfColor()
    {
        StopAllCoroutines();
        StartCoroutine(ChangeTransparency(0f));
    }
    IEnumerator ChangeTransparency(float targetTransparency)
    {
        while (mColor.a != targetTransparency)
        {
            if (mColor.a < targetTransparency)
                if (mColor.a + mTransparencyChange > targetTransparency)
                    mColor.a = targetTransparency;

                else mColor.a += mTransparencyChange;

            else
            {
                if (mColor.a - mTransparencyChange < 0f) mColor.a = 0f;

                else mColor.a -= mTransparencyChange;
            }
            mColorOverlay.color = mColor;
            yield return new WaitForSeconds(Time.deltaTime);
        }
    }
}
