/*****************************************************************************
* Project: GunFactory
* File   : MaterialTransparencyBurst.cs
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
*   15.08.2021	JA	Created
******************************************************************************/
using System.Collections;
using UnityEngine;

/// <summary>
/// Fades in and out of material color
/// </summary>
public class MaterialTransparencyBurst : MonoBehaviour
{
    [SerializeField] MeshRenderer mMeshRenderer;
    Color mColor;
    float mTransparencyChange = 0.1f;

    private void Awake()
    {
        mColor = mMeshRenderer.material.color;
    }

    public void DoColorBurst()
    {
        StopAllCoroutines();
        StartCoroutine(ColorBurst(1f));
    }
    public void EndColorBurst()
    {
        StopAllCoroutines();
        StartCoroutine(ColorBurst(0.2f));
    }

    IEnumerator ColorBurst(float _targetTransparency)
    {
        float targetTransparency = _targetTransparency;
        while (mColor.a != targetTransparency)
        {
            if (Mathf.Abs
                (mColor.a - targetTransparency) < mTransparencyChange)
            {
                mColor.a = targetTransparency;
                continue;
            }

            if (mColor.a < targetTransparency) mColor.a += mTransparencyChange;
            else mColor.a -= mTransparencyChange;

            mMeshRenderer.material.SetColor("_Color", mColor);
            yield return new WaitForFixedUpdate();
        }
    }
}
