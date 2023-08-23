/*****************************************************************************
* Project: GunFactory
* File   : ScreenColorStandalone.cs
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
*   19.08.2021	JA	Created
******************************************************************************/
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Fades in and out of screencolor. Same as the other one but without the 
/// iTrigger interface.
/// </summary>
public class ScreenColorStandalone : MonoBehaviour
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
        mColorOverlay = 
            GameObject.FindGameObjectWithTag("AreaOverlay").GetComponent<Image>();
    }
    private void OnTriggerEnter(Collider other)
    {
        FadeIntoColor();
    }
    private void OnTriggerExit(Collider other)
    {
        FadeOutOfColor();
    }

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
            if (Mathf.Abs(mColor.a - targetTransparency) < mTransparencyChange)
                mColor.a = targetTransparency;
            if (mColor.a < targetTransparency) mColor.a += mTransparencyChange;
            else mColor.a -= mTransparencyChange;
            mColorOverlay.color = mColor;
            yield return new WaitForFixedUpdate();
        }
    }
}
