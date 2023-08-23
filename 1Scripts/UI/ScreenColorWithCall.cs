/*****************************************************************************
* Project: GunFactory
* File   : ScreenColorWithCall.cs
* Date   : 27.08.2021
* Author : Jan Apsel (JA)
*
* These coded instructions, statements, and computer programs contain
* proprietary information of the author and are protected by Federal
* copyright law. They may not be disclosed to third parties or copied
* or duplicated in any form, in whole or in part, without the prior
* written consent of the author.
*
* History:
*   27.08.2021	JA	Created
******************************************************************************/
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ScreenColorWithCall : MonoBehaviour
{
    [SerializeField] private Color mColor;
    [SerializeField] private float mTargetTransparency = 0.5f;
    [SerializeField] private float mTransparencyChange = 0.1f;
    [SerializeField] Image mColorOverlay;
    [SerializeField] GameObject mGameObject;
    [SerializeField] bool isCallOnFull = true;

    public float MTargetTransparency { set { mTargetTransparency = value; } }
    public float MTransparencyChange { set { mTransparencyChange = value; } }
    public Color MColor { set { mColor = value; } }

    private void Awake()
    {

    }
    public void FadeIntoColor()
    {
        StopAllCoroutines();
        StartCoroutine(ChangeTransparency(mTargetTransparency));
    }
    public void FadeOutOfColor()
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
        if(mGameObject!=null)
            if (mColor.a == (isCallOnFull ? 1f : 0f)) mGameObject?.SetActive(true);
    }
}
